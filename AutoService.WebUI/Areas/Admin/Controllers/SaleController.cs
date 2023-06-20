using AutoService.WebUI.Entities;
using AutoService.WebUI.Repositories;
using AutoService.WebUI.Repositories.EfPostgresql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly ICustomerRepository _customerRepository;

        public SaleController(ICarRepository carRepository, IUnitOfWork unitOfWork, ISaleRepository saleRepository, ICustomerRepository customerRepository)
        {
            _carRepository=carRepository;
            _unitOfWork=unitOfWork;
            _saleRepository=saleRepository;
            _customerRepository=customerRepository;
        }

        // GET: SaleController
        public async Task<IActionResult> Index()
        {
            ViewBag.CarId = new SelectList(_carRepository.GetAllAsync(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(_customerRepository.GetAllAsync(), "Id", "Name");
            var sales = _saleRepository.GetAllAsync();
            return View(sales);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.CarId = new SelectList(_carRepository.GetAllAsync(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(_customerRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sale sale)
        {

            try
            {
                await _saleRepository.AddAsync(sale);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("",ModelState.Values.ToString());
            }
            ViewBag.CarId = new SelectList(_carRepository.GetAllAsync(), "Id", "Model");
            ViewBag.CustomerId = new SelectList(_customerRepository.GetAllAsync(), "Id", "Name");
            return RedirectToAction(nameof(Index));
        }


        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
