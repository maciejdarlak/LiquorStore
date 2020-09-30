﻿using System;
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
            return View(cartList);
        }

        public async Task<IActionResult> AddToCart(int Id) //The method checks if the product from the parameter is in the database
        {
            Product product = await _context.Product.FirstOrDefaultAsync(x => x.Id == Id);
            var cart = GetCart();
            cart.AddItem(product, 1);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart)); //To string type
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

        private Cart GetCart() //Session
        {
            var session_cart = HttpContext.Session.GetString("Cart");
            var cart = session_cart != null ? JsonConvert.DeserializeObject<Cart>(session_cart) : new Cart(); //To object type
            return cart;
        }
    }
}

