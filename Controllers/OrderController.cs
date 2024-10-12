﻿using Microsoft.AspNetCore.Mvc;
using Palmart.IRepo;
using Palmart.Models;

namespace Palmart.Controllers
{
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.orders.GetAll());
		}
		public async Task<IActionResult> New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(Order order)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.orders.Insert(order);
				TempData["Success"] = "Order Has Been Added Successfully";
				return RedirectToAction("Index");
			}
			return View(order);
		}
		//public IActionResult Login(LoginInfo loginUser)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var user = _loginRepo.GetByEmail(loginUser.Email);
		//		if (user.Email == loginUser.Email && user.Password == loginUser.Password)
		//		{
		//			return RedirectToAction("Index");
		//		}
		//	}
		//	ModelState.AddModelError("Incorrect", "Email or Password is Incorrect");
		//	return View();
		//}
		//    public IActionResult Contact(Contact contact)
		//    {
		//        if (ModelState.IsValid)
		//        {
		//if (GetLoginInfo()[0]==contact.Email)
		//            {
		//                return RedirectToAction("Index");
		//            }
		//        }
		//        ModelState.AddModelError("Incorrect", "Email is Incorrect");
		//        return View();
		//    }
		public async Task<IActionResult> Edit(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.orders.GetByID(id));
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Order order)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.orders.Update(order);
				TempData["Success"] = "Order Has Been Updated Successfully";
				return RedirectToAction("Index");
			}
			return View(order);
		}
		public async Task<IActionResult> Delete(int id = 0)
		{
			if (id != 0)
			{
				return View(await _unitOfWork.orders.GetByID(id));
			}
			return NotFound();
		}
		[HttpDelete, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteOrder(int id = 0)
		{
			if (id != 0)
			{
				var order = await _unitOfWork.orders.GetByID(id);
				if (order != null)
				{
					_unitOfWork.orders.Delete(order);
					TempData["Success"] = "Order Has Been Deleted Successfully";
					return RedirectToAction("Index");
				}
			}
			return NotFound();

		}
	}
}
