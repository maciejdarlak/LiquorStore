﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Components
{
    public class WinesSubCategoryNavigation : ViewComponent
    {
        private ProductContext _productContext;
        public WinesSubCategoryNavigation(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subcategories = await _productContext.Product.Where(x => x.Category == "Wines").Select(x => x.SubCategory).Distinct().ToListAsync();
            return View(subcategories);
        }
    }
}
