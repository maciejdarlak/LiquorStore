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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = _productContext.Product.Select(x => x).ToList();
            return View(menu);   
        }
    }
}
