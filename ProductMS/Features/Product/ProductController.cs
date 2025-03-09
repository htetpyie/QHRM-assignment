using Microsoft.AspNetCore.Mvc;

namespace ProductMS.Features.Product
{
	public class ProductController : BaseController
	{

		private readonly IProductService _productService;
		private const string PRODUCT = "Product";

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

		[HttpPost]
		public IActionResult Save(ProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				TempData["Message"] = ConstantMessage.InvalidData;
				return RedirectToAction(nameof(Create), model);
			}

			bool isDpulicate = _productService.IsDuplicate(model);
			if (isDpulicate)
			{
				TempData["Message"] = ConstantMessage
					.AlreadyExisted
					.Format(PRODUCT);
				return RedirectToAction(nameof(Create), model);
			}

			int saveResult = _productService.Save(model);
			if (saveResult < 1)
			{
				TempData["Message"] = ConstantMessage.Error;
				return RedirectToAction(nameof(Create), model);
			}

			TempData["Message"] = ConstantMessage
				.CreatedSuccess
				.Format(PRODUCT);
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
				TempData["Message"] = ConstantMessage.InvalidData;
				return View(nameof(Edit), model);
			}

			bool isDpulicate = _productService.IsDuplicate(model);
			if (isDpulicate)
			{
				TempData["Message"] = ConstantMessage
					.AlreadyExisted
					.Format(PRODUCT);
				return View(nameof(Edit), model);
			}

			int updateResult = _productService.Update(model);
			if (updateResult < 1)
			{
				TempData["Message"] = ConstantMessage.Error;
				return View(nameof(Edit), model);
			}

			TempData["Message"] = ConstantMessage
				.UpdatedSuccess
				.Format(PRODUCT);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var productModel = _productService.GetById(id);
			if (productModel is null) return PageNotFound();

			int deleteResult = _productService.Delete(id);
			TempData["Message"] = deleteResult < 1
				? ConstantMessage.Error
				: ConstantMessage.DeleteSuccess.Format(PRODUCT);

			return RedirectToAction(nameof(Index));
		}
	}
}
