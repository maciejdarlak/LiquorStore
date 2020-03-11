using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;

namespace LiquorStore.Controllers
{
    public class AdminController : Controller
    {
        public ProductContext _productContext;

        public AdminController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Category, SubCategory, ProductionYear, Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productContext.Add(product);
                _productContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }



    }
}