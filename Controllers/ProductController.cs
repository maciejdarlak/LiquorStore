using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using Microsoft.EntityFrameworkCore;


namespace LiquorStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductContext _productContext;

        public ProductController (ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IActionResult> List()
        {
            return View(await _productContext.Product.ToListAsync());
        }
    }
}