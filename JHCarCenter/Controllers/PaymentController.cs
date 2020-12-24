using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IRepositoryBase<Payment> _repo;

        public PaymentController(IRepositoryBase<Payment> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var list = _repo.GetAll();
            return View(list);
        }
    }
}
