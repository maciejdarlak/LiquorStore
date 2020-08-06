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
        private readonly ProductContext _context;

        public CartController(ProductContext context) //Depedency Injection
        {
            _context = context;
        }

        public IActionResult CartList()
        {
            var cartList = new CartListViewModel { cart = GetCart() };
            cartList = (CartListViewModel)TempData["data"];
            return View(cartList);
        }

        public async Task<IActionResult> AddToCart(int Id) //The method checks if the product from the parameter is in the database
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                Cart data = GetCart().AddItem(product, 1); //As it is added using the Cart class method       
                TempData["data"] = data;
            }

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> RemoveFromCart(int Id)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                GetCart().RemoveItem(product);
            }

            return RedirectToAction("CartList");
        }

        private Cart GetCart()
        {
            var session = HttpContext.Session.GetString("Cart");

            if (session != null)
            {
                var sessionObj = session == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(session);
                return sessionObj;
            }
            else
            {
                Cart value = new Cart();
                // Adding a session object.
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(value)); // SerializeObject method converts .NET objects into their JSON equivalent.

                // Getting a session object.
                var sessionValue = HttpContext.Session.GetString("Cart");
                var sessionObj = value == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(sessionValue); // DeserializeObject method converts JSON into .NET objects (<Cart>.
                return sessionObj;
            }    
        }
    }
}

