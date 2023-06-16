using AutoService.WebUI.Entities;
using AutoService.WebUI.Repositories;
using AutoService.WebUI.Repositories.EfPostgresql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AutoService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository=brandRepository;
            _unitOfWork=unitOfWork;
        }

        // GET: BrandController
        public async Task<IActionResult> Index()
        {
            var brands = _brandRepository.GetAllAsync();
            ViewBag.CarsName=brands;
            return View(brands);
        }

        // GET: BrandController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            try
            {
                await _brandRepository.AddAsync(brand);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _brandRepository.FindAsync(x => x.Id==id);
            return View(model);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Brand brand)
        {
            try
            {
                await _brandRepository.UpdateAsync(brand);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _brandRepository.FindAsync(x => x.Id==id);
            return View(model);
        }

        // POST: BrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Brand brand)
        {
            try
            {
                await _brandRepository.DeleteAsync(brand);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
