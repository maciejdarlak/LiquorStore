using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;
using Microsoft.EntityFrameworkCore;


namespace LiquorStore.ViewComponents
{
    public class CategoryNavigationViewComponent : ViewComponent
    {
        private ProductContext _productContext;
        public CategoryNavigationViewComponent(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _productContext.Product.OrderBy(x => x.Category).Distinct().ToListAsync();
            return View(menu); 
        }
    }
}