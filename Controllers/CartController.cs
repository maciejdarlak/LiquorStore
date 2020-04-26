using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Models;
using LiquorStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace LiquorStore.Controllers
{
    public class CartController : Controller
    {
        readonly private ProductContext _context;
        public CartController(ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CartList()
        {
            return View (new CartListViewModel { Cart = GetCart() });
        }

        public async Task<IActionResult> AddToCart(int productId) //The method checks if the product from the parameter is in the database
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1); //As it is added using the Cart class method
            }

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                GetCart().RemoveItem(product);
            }

            return RedirectToAction("CartList");
        }

        public Cart GetCart()
        {
            if (cart == null)
            {
                cart = new Cart();
            }
            return cart;
        }
    }
}