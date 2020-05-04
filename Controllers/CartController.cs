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
        readonly private Cart _cart;

        public CartController(ProductContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public async Task<IActionResult> CartList(Cart cart)
        {
            var cartList = new CartListViewModel { Cart = GetCart() };  
            return View(cartList);
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
            Cart cart = new Cart();
            var sesionValue = HttpContext.Session.GetString("Cart");

            var sessionObj = value == null ? default(Cart) : JsonConvert.DeserializeObject<Cart>(sesionValue);

            if (cart == null)
            {
                cart = new Cart();
            }
            return cart(sessionObj);
        }

        public async Task<List<Cart.CartItem>> GetCartItemsAsync()
        {
            return _cart.CartItems ?? (_cart.CartItems = await _cart.CartItems.Where(x => x.Product.Id == Product.Id));
        }
    }
}