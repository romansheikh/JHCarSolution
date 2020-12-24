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
        [HttpGet]
        public IActionResult Create()
        {
            List<Accessories> paymentType = new List<Accessories>();
            paymentType.Add(new Accessories { AccessoriesID = 0, AccessoriesName = "Select One" });
            paymentType.Add(new Accessories { AccessoriesID = 1, AccessoriesName = "Cash" });
            paymentType.Add(new Accessories { AccessoriesID = 2, AccessoriesName = "Demand Draft" });
            paymentType.Add(new Accessories { AccessoriesID = 3, AccessoriesName = "Check" });
            paymentType.Add(new Accessories { AccessoriesID = 4, AccessoriesName = "Pay Order" });
            ViewBag.Type = paymentType;
            return View();
        } 
        [HttpPost]
        public async Task< IActionResult> Create(Payment payment)
        {
            _repo.Add(payment);
            await _repo.SaveAsync(payment);
            return View();
        }
     
    }
}
