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
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

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
			Console.WriteLine("Wait...");
			if (ModelState.IsValid)
			{
				Console.WriteLine("Wait...2...");

				_unitOfWork.users.Insert(user);
				Console.WriteLine("Done...!");
				TempData["Success"] = "User Has Been Added Successfully";
				return RedirectToAction("Index");
			}
			return View(user);
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
