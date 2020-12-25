using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IRepositoryBase<Sales> _repo;
        private readonly IRepositoryBase<Quatation> _qRepo;
        private readonly IRepositoryBase<Vehicle> _vRepo;
        private readonly IRepositoryBase<Customer> _cRepo;

        public DeliveryController(IRepositoryBase<Sales> repo,IRepositoryBase<Quatation> qRepo,IRepositoryBase<Vehicle> vRepo,IRepositoryBase<Customer> cRepo)
        {
            _repo = repo;
            _qRepo = qRepo;
            _vRepo = vRepo;
            _cRepo = cRepo;
        }
        public IActionResult Index()
        {
            List<Sales> sales = _repo.GetAll().ToList();
            foreach (var item in sales)
            {
                Quatation q = _qRepo.GetById(item.QuatationID);
                Vehicle v = _vRepo.GetById(q.VehicleID);
                Customer c = _cRepo.GetById(q.CustomerID);
                q.Customer = c;
                q.Vehicle = v;
                item.Quatation = q;
            }
            return View(sales);
        }
        public IActionResult Pending()
        {
            List<Sales> sales= _repo.GetAll().ToList();
            List<Sales> pending = sales.Where(x => x.IsDeliverd == false).ToList();
            foreach (var item in pending)
            {
                Quatation q = _qRepo.GetById(item.QuatationID);
                Vehicle v = _vRepo.GetById(q.VehicleID);
                Customer c = _cRepo.GetById(q.CustomerID);
                q.Customer = c;
                q.Vehicle = v;
                item.Quatation = q;
            }
            return View(pending);
        }
    }
}
