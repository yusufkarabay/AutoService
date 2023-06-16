using AutoService.WebUI.Entities;
using AutoService.WebUI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository=roleRepository;
            _unitOfWork=unitOfWork;
        }

        // GET: RoleController1
        public async Task<IActionResult> Index()
        {
            var roles = _roleRepository.GetAllAsync();
            return View(roles);
        }

        // GET: RoleController1/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: RoleController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                await _roleRepository.AddAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController1/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _roleRepository.FindAsync(x => x.Id==id);
            return View(model);
        }

        // POST: RoleController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Role role)
        {
            try
            {
                await _roleRepository.UpdateAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController1/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _roleRepository.FindAsync(x => x.Id==id);
            return View(model);
        }

        // POST: RoleController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Role role)
        {
            try
            {
                await _roleRepository.DeleteAsync(role);
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
