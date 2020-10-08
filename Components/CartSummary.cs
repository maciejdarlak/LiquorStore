using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;
using LiquorStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LiquorStore.Components
{
    public class CartSummary : ViewComponent
    {
        private ProductContext _context;
        public CartSummary(ProductContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartSummary = await _context.Product.TakeAsync();
            return View(cartSummary);
        }
    }
}