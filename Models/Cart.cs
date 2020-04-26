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
        private List<CartItem> CartItems = new List<CartItem>();  //CartItem = Product * x       

        public void AddItem(Product product, int quantity)
        {
            CartItem cartItem = CartItems.Where(x => x.Product.Id == product.Id).FirstOrDefault();  //Product search from parameter

            if (cartItem == null) //Product from parameter does not exist in Cart, so has to be created new object in the CartItems list
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else //The product exist in Cart (as an object) so just add a new quantity
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
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
