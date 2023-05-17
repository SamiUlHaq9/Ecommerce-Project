using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserPayment()
        {
            return View();
        }
        public IActionResult CustomSetup()
        {
            return View();
        }
        public IActionResult SubCategory()
        {
            return View();
        }

        public IActionResult ItemSetupDetail()
        {
            return View();
        }

        public IActionResult ItemSetup()
        {
            return View();
        }

        public IActionResult ItemSpecification()
        {
            return View();
        }
        public IActionResult ItemBrand()
        {
            return View();
        }

        public IActionResult OrderMaster()
        {
            return View();
        }

        public IActionResult CustomerDetail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
