using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquorStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products;
        public string CurrentCategory;
    }
}
