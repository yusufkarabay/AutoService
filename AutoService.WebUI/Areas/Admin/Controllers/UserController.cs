using AutoService.WebUI.Entities;
using AutoService.WebUI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoService.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            _userRepository=userRepository;
            _unitOfWork=unitOfWork;
            _roleRepository=roleRepository;
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = _userRepository.GetAllAsync();
            
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: UserController/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.RoleId=new SelectList( _roleRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            
                try
                {
                    await _userRepository.AddAsync(user);
                    await _unitOfWork.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu");
                }
            
            ViewBag.RoleId=new SelectList( _roleRepository.GetAllAsync(), "Id", "Name");
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.RoleId=new SelectList( _roleRepository.GetAllAsync(), "Id", "Name");
            var model = await  _userRepository.FindAsync(x=>x.Id==id);
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, User user)
        {

            try
            {
                await _userRepository.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu");
            }

            ViewBag.RoleId=new SelectList( _roleRepository.GetAllAsync(), "Id", "Name");
            return View(user);
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            ViewBag.RoleId=new SelectList(  _roleRepository.GetAllAsync(), "Id", "Name");
            var model = await _userRepository.FindAsync(x => x.Id==id);
            return View(model);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, User user)
        {


            try
            {
                await _userRepository.DeleteAsync(user);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu");
            }

            ViewBag.RoleId=new SelectList( _roleRepository.GetAllAsync(), "Id", "Name");
            return RedirectToAction(nameof(Index));
        }
    }
}
