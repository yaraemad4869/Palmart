using Microsoft.AspNetCore.Mvc;
using Palmart.Repo;
using Palmart.Models;
using Palmart.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Palmart.Data.Enums;
using Palmart.IRepo;

namespace Palmart.Controllers
{
	public class UserController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILoginRepo _loginRepo;
        public UserController(IUnitOfWork unitOfWork, ILoginRepo loginRepo)
        {
            _unitOfWork = unitOfWork;
			_loginRepo = loginRepo;

        }
        public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.users.GetAll());
		}
		public async Task<IActionResult> New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(User user)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.users.Insert(user);
				TempData["Success"] = "User Has Been Added Successfully";
				return RedirectToAction("Index");
			}
			return View(user);
		}
		public  IActionResult Login(LoginInfo loginUser)
		{
			if (ModelState.IsValid)
			{
				var user =  _loginRepo.GetByEmail(loginUser.Email);
				if(user.Email==loginUser.Email && user.Password==loginUser.Password)
				{ 
					return RedirectToAction("Index"); 
				}
			}
			ModelState.AddModelError("Incorrect", "Email or Password is Incorrect");
			return View();
		}
		public async Task<IActionResult> Edit(int id=0)
		{
			if(id!=0)
			{
				return View(await _unitOfWork.users.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.users.Update(user);
				TempData["Success"] = "User Has Been Updated Successfully";
				return RedirectToAction("Index");
			}
			return View(user);
		}
		public async Task<IActionResult> Delete(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.users.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id = 0)
        {
			var user = await _unitOfWork.users.GetByID(id);
			if (id != 0 && user !=null)
			{
				_unitOfWork.users.Delete(user);
				TempData["Success"] = "User Has Been Deleted Successfully";
				return RedirectToAction("Index");
			}
			return NotFound();
			
        }

    }
}
