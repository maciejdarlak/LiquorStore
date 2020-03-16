using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;
using Microsoft.EntityFrameworkCore;


namespace LiquorStore.Controllers
{
    public class AdminController : Controller
    {
        public ProductContext _productContext;

        public AdminController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<ViewResult> Index()
        {
            return View(await _productContext.Product.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Category, SubCategory, Volume, ProductionYear, Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productContext.Add(product);
                await _productContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productContext.Product.FirstOrDefaultAsync(x => x.Id == id);  

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id, Name, Category, SubCategory, Volume, ProductionYear, Price")] Product product)
        {
            if (Id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productContext.Update(product);
                    await _productContext.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!_productContext.Product.Any(x => x.Id == Id))
                    {
                        return NotFound();
                    }
                    else
                        throw;
                }
               
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}