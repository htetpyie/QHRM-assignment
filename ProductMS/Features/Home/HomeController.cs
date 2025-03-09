using Microsoft.AspNetCore.Mvc;

namespace ProductMS.Features.Home
{
	public class HomeController : Controller
	{
		public IActionResult Error(string message)
		{
			return View(message);
		}

		public IActionResult PageNotFound()
		{
			return View();
		}
	}
}
