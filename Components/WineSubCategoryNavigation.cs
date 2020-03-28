using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Components
{
    public class WineSubCategoryNavigation : ViewComponent
    {
        private ProductContext _context;
        public WineSubCategoryNavigation(ProductContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subcategories = await _context.Product.Where(x => x.Category == "Wine").Select(x => x.SubCategory).Distinct().ToListAsync();
            return View(subcategories);
        }
    }
}
