using AutoService.WebUI.Entities;
using AutoService.WebUI.Repositories;
using AutoService.WebUI.Repositories.EfPostgresql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBrandRepository _brandRepository;



        public CarController(ICarRepository carRepository, IUnitOfWork unitOfWork, IBrandRepository brandRepository)
        {
            _carRepository=carRepository;
            _unitOfWork=unitOfWork;
            _brandRepository=brandRepository;
        }

        // GET: CarController
        public async Task<IActionResult> Index()
        {
            ViewBag.BrandId=new SelectList(_brandRepository.GetAllAsync(), "Id", "Name");
        
            var cars = _carRepository.GetAllAsync();
            return View(cars);
        }
        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.BrandId=new SelectList( _brandRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            try
            {
                await _carRepository.AddAsync(car);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu");
            }
            ViewBag.BrandId=new SelectList( _brandRepository.GetAllAsync(), "Id", "Name");
            return RedirectToAction(nameof(Index));
        }
        // GET: CarController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.BrandId=new SelectList( _brandRepository.GetAllAsync(), "Id", "Name");
            var model = await _carRepository.FindAsync(x => x.Id==id);
            return View(model);
        }


        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Car car)
        {
            try
            {
                await _carRepository.UpdateAsync(car);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.BrandId=new SelectList(_brandRepository.GetAllAsync(), "Id", "Name");
                return View();
            }
        }



        // GET: CarController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            var model = await _carRepository.FindAsync(x => x.Id==id);
            model.Brand = await _brandRepository.FindAsync(x => x.Id==model.BrandId);
            return View(model);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Car car)
        {
            try
            {
                await _carRepository.DeleteAsync(car);
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
