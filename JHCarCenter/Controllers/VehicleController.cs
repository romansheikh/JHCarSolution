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
    public class VehicleController : Controller
    {
        private readonly IRepositoryBase<Vehicle> _repo;
        private readonly IRepositoryBase<Color> _crepo;
        private readonly IRepositoryBase<VehicleAccessories> _varepo;
        private readonly IRepositoryBase<Accessories> _aRepo;
        private readonly IRepositoryBase<VehicleType> _tRepo;

        public VehicleController(IRepositoryBase<Vehicle> repo, IRepositoryBase<Color> crepo,IRepositoryBase<VehicleAccessories> varepo,IRepositoryBase<Accessories> aRepo,IRepositoryBase<VehicleType> tRepo)
        {
            _repo = repo;
            _crepo = crepo;
            _varepo = varepo;
            _aRepo = aRepo;
            _tRepo = tRepo;
        }
        public IActionResult Index()
        {
            var vehicleList = _repo.GetAll();
            return View(vehicleList);
        } 
        public IActionResult Details(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Color> g = new List<Color>();
            g.Add(new Color { ColorID = 0, ColorName = "Select One" });
            g.AddRange(_crepo.GetAll().ToList());
            ViewBag.Color = g;

            List<VehicleType> t = new List<VehicleType>();
            t.Add(new VehicleType { VehicleTypeID = 0, Type = "Select One" });
            t.AddRange(_tRepo.GetAll().ToList());
            ViewBag.Type = t;

            List<Accessories> a = new List<Accessories>();
            a.Add(new Accessories { AccessoriesID = 0, AccessoriesName = "Select That apply" });
            a.AddRange(_aRepo.GetAll().ToList());
            ViewBag.Accessories = a;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VehicleAddVM v)
        {
            Vehicle vehicle = new Vehicle
            {

                VehicleName = v.VehicleName,
                VehicleTypeID = v.VehicleTypeID,
                ChassisNo = v.ChassisNo,
                Cubic_Capacity = v.Cubic_Capacity,
                EngineNo = v.EngineNo,
                LoadCapacity = v.LoadCapacity,
                ManfactureYear = v.ManfactureYear,
                IsSales = v.IsSales,
                UnitPrice = v.UnitPrice,
                ColorID = v.ColorID,
                VehicleID = v.VehicleID,



            };
            _repo.Add(vehicle);
            await _repo.SaveAsync(vehicle);
            int vehicleid = vehicle.VehicleID;
            foreach (var item in v.AccessoriesIds)
            {
                VehicleAccessories va = new VehicleAccessories { VehicleID = vehicleid, AccessoriesID = item };
                _varepo.Add(va);
                await _varepo.SaveAsync(va);
            }

            return RedirectToAction("Index", "Vehicle");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<VehicleType> t = new List<VehicleType>();
            t.Add(new VehicleType { VehicleTypeID = 0, Type = "Select One" });
            t.AddRange(_tRepo.GetAll().ToList());
            ViewBag.Type = t;

            var veh = _repo.GetById(id);
            List<Color> g = new List<Color>();
            g.Add(new Color { ColorID = 0, ColorName = "Select One" });
            g.AddRange(_crepo.GetAll().ToList());
            ViewBag.Color = g;
            return View(veh);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Vehicle vehicle)
        {
            _repo.Update(vehicle);
            await _repo.SaveAsync(vehicle);
            return RedirectToAction("Index", "Vehicle");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var veh = _repo.GetById(id);
            return View(veh);
        }
        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            _repo.Delete(vehicle);
            _repo.SaveAsync(vehicle);
            return View();
        }
    }
}
