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
			try
			{
				var datatableRequestModel = GetDataTableRequest();
				var response = _productService.GetList(datatableRequestModel);
				return Ok(response);
			}
			catch (Exception)
			{
				throw;
			}

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

		public IActionResult Edit(int id)
		{
			var productModel = _productService.GetById(id);

			if (productModel is null) return PageNotFound();

			return View(productModel);
		}

		[HttpPost]
		public IActionResult Update(ProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				TempData["Message"] = "Your data is not valid. Please try again!";
				return View(nameof(Edit), model);
			}

			bool isDpulicate = _productService.IsDuplicate(model);
			if (isDpulicate)
			{
				TempData["Message"] = "Product is already existed!";
				return View(nameof(Edit), model);
			}

			int updateResult = _productService.Update(model);
			if (updateResult < 1)
			{
				TempData["Message"] = "Something went wrong. Please try again!";
				return View(nameof(Edit), model);
			}

			TempData["Message"] = "Product is updated successfully!";
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var productModel = _productService.GetById(id);
			if (productModel is null) return PageNotFound();

			int deleteResult = _productService.Delete(id);
			TempData["Message"] = deleteResult < 1
				? "Something went wrong. Please try again!"
				: "Product is deleted successfully!";

			return RedirectToAction(nameof(Index));
		}
	}
}
