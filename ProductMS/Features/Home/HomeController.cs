using Microsoft.AspNetCore.Mvc;

namespace ProductMS.Features.Home
{
	public class HomeController : Controller
	{
		public IActionResult Error()
		{
			return View();
		}

		public IActionResult NotFoundPage()
		{
			return View();
		}
	}
}
