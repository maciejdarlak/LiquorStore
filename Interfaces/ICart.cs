using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Models;

namespace LiquorStore.Interfaces
{
    public interface ICart
    {
        public void AddItem(Product product, int quantity);
    }
}
