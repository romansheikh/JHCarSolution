using JHCarCenter.Models;
using JHCarCenter.Repositoty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Controllers
{
    public class ColorController : Controller
    {
        private readonly Repositoty.IRepositoryBase<Color> _repo;

        public ColorController(IRepositoryBase<Color> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var color = _repo.GetAll();
            return View(color);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            _repo.Add(color);
            await _repo.SaveAsync(color);
            return View(color);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var color = _repo.GetById(id);
            return View(color);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Color color)
        {
            _repo.Update(color);
            await _repo.SaveAsync(color);
            return View(color);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var color = _repo.GetById(id);
            return View(color);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Color color)
        {
            _repo.Delete(color);
            await _repo.SaveAsync(color);
            return View(color);
        }



    }
}
