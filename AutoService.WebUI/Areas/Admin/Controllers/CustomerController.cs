using AutoService.WebUI.Entities;
using AutoService.WebUI.Repositories;
using AutoService.WebUI.Repositories.EfPostgresql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _carRepository;

        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _customerRepository=customerRepository;
            _unitOfWork=unitOfWork;
            _carRepository=carRepository;
        }

        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var customers =  _customerRepository.GetAllAsync();
            return View(customers);


        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.CarId= new SelectList(_carRepository.GetAllAsync(), "Id", "Model");
          
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {

            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu");
            }

            ViewBag.CarId = new SelectList( _carRepository.GetAllAsync(), "Id", "Model");
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.CarId = new SelectList( _carRepository.GetAllAsync(), "Id", "Model");
            var customer = await _customerRepository.FindAsync(x=>x.Id==id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
