using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace LiquorStore.Models
{
    public class Cart
    {
        public string CartId { get; set; }

        private List<CartItem> CartItems = new List<CartItem>();  //CartItem = Product * x       

        public void AddItem(Product product, int quantity)
        {
            CartItem cartItem = CartItems.Where(x => x.Product.Id == product.Id).FirstOrDefault();  //Products comparison

            if (CartItems == null)
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            CartItem cartItem = CartItems.Where(x => x.Product.Id == product.Id).FirstOrDefault();

            CartItems.RemoveAll(x => x.Product.Id == product.Id);
        }

        public void RemoveAll()
        {
            CartItems.Clear();
        }

        public IEnumerable<CartItem> CartItemsReview
        {
           get { return CartItems; } 
        }

        public class CartItem
        {
            public string CartId { get; set; }
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
