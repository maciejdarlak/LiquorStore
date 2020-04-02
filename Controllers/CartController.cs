using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Models;
using LiquorStore.Data;
using Microsoft.EntityFrameworkCore;


namespace LiquorStore.Controllers
{
    public class CartController : Controller
    {
        readonly private ProductContext _Context;
        public CartController(ProductContext Context)
        {
            _Context = Context;
        }

        public async Task<IActionResult> AddToCart(Cart cart, int productId)
        {
            Product product = await _Context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> RemoveFromCart(Cart cart, int productId)
        {
            Product product = await _Context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                cart.RemoveItem(product);
            }

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> Summary(Cart cart )
        {
            return View(cart);
        }

        public async Task<IActionResult> AdminList(Cart cart)
        {
            IEnumerable<Product> products = await _Context.Product.Select(x => x).ToListAsync();
            return RedirectToAction("CartList");
        }
    }
}