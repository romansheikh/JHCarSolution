using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class DeliveryController : Controller
    {
        public DeliveryController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
