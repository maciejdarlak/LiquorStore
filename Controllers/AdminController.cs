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
        public ProductContext _bottleContext;

        public AdminController(ProductContext bottleContext)
        {
            _bottleContext = bottleContext;
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}