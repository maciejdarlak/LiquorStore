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
    public class SubCategoryNavigationViewComponent : ViewComponent
    {
        private ProductContext _productContext;
        public SubCategoryNavigationViewComponent(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subcategory = await _productContext.Product.OrderBy(x => x.SubCategory).Distinct().ToListAsync();
            return View(subcategory);
        }
    }
}
