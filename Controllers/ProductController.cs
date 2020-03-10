using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;

namespace LiquorStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductContext _productContext;

        public ProductController (ProductContext productContext)
        {
            _productContext = productContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}