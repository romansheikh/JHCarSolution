using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class SalesController : Controller
    {
        private readonly IQutationRepository _qRepo;

        public SalesController(IQutationRepository qRepo)
        {
            _qRepo = qRepo;
        }
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Challan(int id)
        {
            var item = _qRepo.GetQuatationById(id);
            return View(item);
        }
    }
}
