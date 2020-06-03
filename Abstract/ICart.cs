using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Models;


namespace LiquorStore.Abstract
{
    public interface ICart
    {
        public void AddItem(Product product, int quantity);
        public void RemoveItem(Product product);
        public void RemoveAll();
        public IEnumerable<Cart.CartItem> CartItemsReview { get; }
    }
}
