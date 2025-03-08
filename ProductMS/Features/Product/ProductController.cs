using Microsoft.AspNetCore.Mvc;

namespace ProductMS.Features.Product
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
