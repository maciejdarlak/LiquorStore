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

        public async Task<IActionResult> CartList(Cart cart)
        {
            return View (new CartListViewModel { Cart = GetCart(cart) });
        }

        public async Task<IActionResult> AddToCart(int productId, Cart cart)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> RemoveFromCart(int productId, Cart cart)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                cart.RemoveItem(product);
            }

            return RedirectToAction("CartList");
        }

        public Cart GetCart(Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart();
            }
            return cart;
        }
    }
}