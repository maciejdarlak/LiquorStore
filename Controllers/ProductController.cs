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

        public async Task<IActionResult> ProductList(string subcategory)
        {
            var model = await _context.Product.OrderBy(p => p.Id).Where(p => subcategory == null || p.SubCategory == subcategory).ToListAsync();                  
            return View(model);
        }
   
        public async Task<IActionResult> SearchList(string searchString)
        {
            var products = await _context.Product.Select(x => x).Where(x => x.Name.Contains(searchString)).ToListAsync();
            return View(products);
        }
    }
}