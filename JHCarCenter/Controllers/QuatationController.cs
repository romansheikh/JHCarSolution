using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using JHCarCenter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class QuatationController : Controller
    {
        private readonly IRepositoryBase<Quatation> _repo;
        private readonly IRepositoryBase<Vehicle> _vehrepo;
        private readonly IRepositoryBase<Customer> _cusrepo;
        private readonly IQutationRepository _qRepo;
        private readonly IRepositoryBase<Sales> _sRepo;

        public QuatationController(IRepositoryBase<Quatation> repo,
                                   IRepositoryBase<Vehicle> vehrepo,
                                   IRepositoryBase<Customer> cusrepo,
                                   IQutationRepository qRepo,IRepositoryBase<Sales> sRepo)
        {
            _repo = repo;
            _vehrepo = vehrepo;
            _cusrepo = cusrepo;
            _qRepo = qRepo;
            _sRepo = sRepo;
        }
        public IActionResult Index()
        {
            var list = _repo.GetAll();
            return View(list);
        }
           public IActionResult Details(int id)
        {
            var item = _qRepo.GetQuatationById(id);
            return View(item);
        }
        
        public IActionResult SelectVehicle(int customerId)
        {
            SelectVehicleVM vehicles = new SelectVehicleVM();
            List<Vehicle> veh = new List<Vehicle>();
            vehicles.Customer= _cusrepo.GetById(customerId); 
            var list = _vehrepo.GetAll();
            foreach (var item in list)
            {
                if (!item.IsSales)
                {
                    veh.Add(item);
                }
            }
            vehicles.Vehicles = veh;
            return View(vehicles);
        }



        [HttpGet]
        public IActionResult Create(int vid,int cid)
        {
            Customer c = _cusrepo.GetById(cid);
            ViewBag.Customer = c;
            Vehicle v = _vehrepo.GetById(vid);
            ViewBag.Vehicle = v;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Quatation quatation)
        {
            quatation.QuatationCreateDate = DateTime.Now;
            _repo.Add(quatation);
            await _repo.SaveAsync(quatation);
            return RedirectToAction("Details",new { id=quatation.QuatationID});
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var q = _repo.GetById(id);
            return View(q);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Quatation quatation)
        {
            _repo.Update(quatation);
            await _repo.SaveAsync(quatation);
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var q = _repo.GetById(id);
            return View(q);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Quatation quatation)
        {
            _repo.Delete(quatation);
            await _repo.SaveAsync(quatation);
            return View();
        }


        public async Task<IActionResult> Confirm(int id)
        {
            var q = _repo.GetById(id);
            q.IsSales = true;
            q.ConfrimationDate = DateTime.Now;
            _repo.Update(q);
            await _repo.SaveAsync(q);
            Sales s = new Sales
            {
                QuatationID = q.QuatationID,
                DelivaryLastDate = DateTime.Now.AddDays(q.DelivaryPeriod)
            };
            _sRepo.Add(s);
            await _sRepo.SaveAsync(s);

            return View(q);
        }

        public IActionResult Print(int id)
        {
            var q = _repo.GetById(id);
            return View(q);
        }

    }
}
