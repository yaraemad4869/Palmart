using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using Palmart.IRepo;
using Palmart.Models;
using Palmart.Repo;

namespace Palmart.Controllers
{
	public class BrandController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;
		public BrandController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.brands.GetAll());
		}
		public async Task<IActionResult> New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(Brand brand)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.brands.Insert(brand);
				TempData["Success"] = "Brand Has Been Added Successfully";
				return RedirectToAction("Index");
			}
			return View(brand);
		}
		public async Task<IActionResult> Edit(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.brands.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Brand brand)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.brands.Update(brand);
				TempData["Success"] = "Brand Has Been Updated Successfully";
				return RedirectToAction("Index");
			}
			return View(brand);
		}
		public async Task<IActionResult> Delete(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.brands.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteBrand(int id = 0)
		{
			var brand = await _unitOfWork.brands.GetByID(id);
			if (id != 0 && brand != null)
			{
				_unitOfWork.brands.Delete(brand);
				TempData["Success"] = "Brand Has Been Deleted Successfully";
				return RedirectToAction("Index");
			}
			return NotFound();

		}
	}
}
