using Microsoft.AspNetCore.Mvc;

namespace Palmart.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
