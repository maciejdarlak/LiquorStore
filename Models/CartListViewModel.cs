using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Models;
using LiquorStore.Abstract;


namespace LiquorStore.Models
{
    public class CartListViewModel
    {
        public ICart cart { get; set; }
    }
}
