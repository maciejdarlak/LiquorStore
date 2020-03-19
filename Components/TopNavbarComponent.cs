using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;

namespace LiquorStore.ViewComponents
{
    public class TopNavbarComponent : ViewComponent
    {
        private ProductContext _productContext;
        public TopNavbarComponent(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public IViewComponentResult Invoke()
        {
            var menu = _productContext.Product.GroupBy(item => new { category = item.Category, subcategory = item.SubCategory }). 
                                               Select(group => new { category2 = group.Key.category, subcategory2 = group.Key.subcategory, Count = group.Count() });
            return View(menu);   
        }
    }
}
