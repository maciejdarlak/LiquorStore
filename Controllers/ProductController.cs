using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using Microsoft.EntityFrameworkCore;
using LiquorStore.Models;


namespace LiquorStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductContext _context;

        public ProductController (ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Product.ToListAsync());
        }

        public async Task<IActionResult> SelectedProductsList(string subcategory)
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = _context.Product
                .OrderBy(p => p.Id)
                .Where(p => subcategory == null || p.SubCategory == subcategory),
                CurrentCategory = subcategory
            };   
            
            return View(model);
        }
    }
}