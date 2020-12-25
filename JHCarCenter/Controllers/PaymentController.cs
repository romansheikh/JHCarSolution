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
        private readonly IRepositoryBase<Sales> _sRepo;
        private readonly IRepositoryBase<Quatation> _qRepo;

        public PaymentController(IRepositoryBase<Payment> repo,IRepositoryBase<Sales> sRepo,IRepositoryBase<Quatation> qRepo)
        {
            _repo = repo;
            _sRepo = sRepo;
            _qRepo = qRepo;
        }
        public IActionResult Index()
        {
            var list = _repo.GetAll();
            return View(list);
        } 
        [HttpGet]
        public IActionResult Create(int id)
        {
            Payment p = new Payment();
            Sales s = _sRepo.GetById(id);
            Quatation q = _qRepo.GetById(s.QuatationID);
            p.SalesID = id;
            p.Amount = q.Price;
            List<Accessories> paymentType = new List<Accessories>();
            paymentType.Add(new Accessories { AccessoriesID = 0, AccessoriesName = "Select One" });
            paymentType.Add(new Accessories { AccessoriesID = 1, AccessoriesName = "Cash" });
            paymentType.Add(new Accessories { AccessoriesID = 2, AccessoriesName = "Demand Draft" });
            paymentType.Add(new Accessories { AccessoriesID = 3, AccessoriesName = "Check" });
            paymentType.Add(new Accessories { AccessoriesID = 4, AccessoriesName = "Pay Order" });
            ViewBag.Type = paymentType;
            return View(p);
        } 
        [HttpPost]
        public async Task< IActionResult> Create(Payment payment)
        {
            _repo.Add(payment);
            await _repo.SaveAsync(payment);
            Sales s = _sRepo.GetById(payment.SalesID);
            s.IsDeliverd = true;
            _sRepo.Update(s);
            await _sRepo.SaveAsync(s);
            return RedirectToAction("Index","Delivery");
        }
     
    }
}
