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
using LiquorStore.Abstract;


namespace LiquorStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductContext _context;
        private readonly ICart _cart;

        public CartController(ProductContext context, ICart cart) //Depedency Injection - services.AddScoped<ICart, Cart>() in Startup
        {
            _context = context;
            _cart = cart;
        }

        public async Task<IActionResult> CartList()
        {
            var cartList = new CartListViewModel { cart = GetCart() };  
            return View(cartList);
        }

        public async Task<IActionResult> AddToCart(int Id) //The method checks if the product from the parameter is in the database
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                GetCart().AddItem(product, 1); //As it is added using the Cart class method
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
            Cart sessionValue = new Cart();

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(sessionValue));

            var sesionValue = HttpContext.Session.GetString("Cart");       
            var sessionObj = sessionValue == null ? new Cart() : JsonConvert.DeserializeObject<Cart>(sesionValue);
            return sessionObj;
        }
    }
}

