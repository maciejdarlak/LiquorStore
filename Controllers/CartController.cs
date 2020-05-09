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
using Newtonsoft.Json;


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
            var cartList = new CartListViewModel { Cart = GetCart() };  
            return View(cartList);
        }

        public async Task<IActionResult> AddToCart(int productId, Cart cart) //The method checks if the product from the parameter is in the database
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1); //As it is added using the Cart class method
            }

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> RemoveFromCart(int productId, Cart cart)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == productId);

            if (product != null)
            {
                GetCart().RemoveItem(product);
            }

            return RedirectToAction("CartList");
        }

        private Cart GetCart()
        {
            var sessionValue = HttpContext.Session.GetString("Cart");
            var sessionObj = sessionValue == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(sessionValue);
            return sessionObj;
        }
    }
}