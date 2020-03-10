using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Data;

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
    }
}