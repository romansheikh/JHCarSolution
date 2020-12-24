using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Challan(int id)
        {
            return View();
        }
    }
}
