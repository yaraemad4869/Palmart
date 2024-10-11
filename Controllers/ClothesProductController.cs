using Microsoft.AspNetCore.Mvc;
using Palmart.IRepo;
using Palmart.Models;

namespace Palmart.Controllers
{
	public class ClothesProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ClothesProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.clothesProducts.GetAll());
		}
		public async Task<IActionResult> New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(ClothesProduct clothesProducts)
		{
			Console.WriteLine("Wait...");
			if (ModelState.IsValid)
			{
				Console.WriteLine("Wait...2...");

				_unitOfWork.clothesProducts.Insert(clothesProducts);
				Console.WriteLine("Done...!");
				TempData["Success"] = "Clothes Has Been Added Successfully";
				return RedirectToAction("Index");
			}
			return View(clothesProducts);
		}
		public async Task<IActionResult> Edit(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.clothesProducts.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ClothesProduct clothesProducts)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.clothesProducts.Update(clothesProducts);
				TempData["Success"] = "Clothes Has Been Updated Successfully";
				return RedirectToAction("Index");
			}
			return View(clothesProducts);
		}
		public async Task<IActionResult> Delete(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.clothesProducts.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteClothes(int id = 0)
		{
			var clothesProduct = await _unitOfWork.clothesProducts.GetByID(id);
			if (id != 0 && clothesProduct != null)
			{
				_unitOfWork.clothesProducts.Delete(clothesProduct);
				TempData["Success"] = "Clothes Has Been Deleted Successfully";
				return RedirectToAction("Index");
			}
			return NotFound();

		}
	}
}
