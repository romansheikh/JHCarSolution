using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepositoryBase<Customer> _repo;
        private readonly IRepositoryBase<Gender> _g_Repo;

        public CustomerController(IRepositoryBase<Customer> repo, IRepositoryBase<Gender> g_repo)
        {
            _repo = repo;
            _g_Repo = g_repo;
        }

        public IActionResult Index()
        {
            var list = _repo.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Gender> g = new List<Gender>();
            g.Add(new Gender { GenderID = 0, GenderName = "Select One" });
            g.AddRange(_g_Repo.GetAll().ToList());
            ViewBag.Genders = g;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            _repo.Add(customer);
            await _repo.SaveAsync(customer);
            return RedirectToAction("SelectVehicle","Quatation",new { customerId =customer.CustomerID});
        }
        [HttpGet]
        public IActionResult Update(int id)
        {

            List<Gender> g = new List<Gender>();
            g.Add(new Gender { GenderID = 0, GenderName = "Select One" });
            g.AddRange(_g_Repo.GetAll().ToList());
            ViewBag.Genders = g;
            var customer = _repo.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            _repo.Update(customer);
            await _repo.SaveAsync(customer);
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _repo.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _repo.Delete(customer);
            _repo.SaveAsync(customer);
            return View();
        }
    }
}
