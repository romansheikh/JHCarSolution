using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IRepositoryBase<Accessories> _repo;
        private readonly IAccessoriesRepo _getRepo;

        public AccessoriesController(IRepositoryBase<Accessories> repo, IAccessoriesRepo getRepo)
        {
            _repo = repo;
            _getRepo = getRepo;
        }
        public IActionResult Index()
        {
            var a = _repo.GetAll();
            return View(a);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Accessories accessories)
        {
            _repo.Add(accessories);
            await _repo.SaveAsync(accessories);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
           Accessories accessories = _repo.GetById(id);
            return View(accessories);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Accessories accessories)
        {
            _repo.Update(accessories);
            await _repo.SaveAsync(accessories);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Accessories accessories = _repo.GetById(id);
            return View(accessories);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Accessories accessories)
        {
            _repo.Delete(accessories);
            await _repo.SaveAsync(accessories);
            return RedirectToAction("Index");
        }
    }


}
