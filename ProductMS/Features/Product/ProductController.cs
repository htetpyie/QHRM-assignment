using Microsoft.AspNetCore.Mvc;

namespace ProductMS.Features.Product
{
	public class ProductController : BaseController
	{

		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult DataList()
		{
			var datatableRequestModel = GetDataTableRequest();
			var response = _productService.GetList(datatableRequestModel);
			return Ok(response);
		}

		public IActionResult Create(ProductViewModel model)
		{
			return View(model);
		}

		public IActionResult Save(ProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				TempData["Message"] = "Your data is not valid. Please try again!";
				return RedirectToAction(nameof(Create), model);
			}

			bool isDpulicate = _productService.IsDuplicate(model);
			if (isDpulicate)
			{
				TempData["Message"] = "Product is already existed!";
				return RedirectToAction(nameof(Create), model);
			}

			int saveResult = _productService.Save(model);
			if (saveResult < 1)
			{
				TempData["Message"] = "Something went wrong. Please try again!";
				return RedirectToAction(nameof(Create), model);
			}

			TempData["Message"] = "Product is created successfully!";
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(string id)
		{
			return View();
		}
	}
}
