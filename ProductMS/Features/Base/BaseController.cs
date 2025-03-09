using Microsoft.AspNetCore.Mvc;

namespace ProductMS.Features.Base
{
	public class BaseController : Controller
	{
		protected DatatableRequestModel GetDataTableRequest()
		{
			var draw = Request.Form["draw"].FirstOrDefault();
			var start = Request.Form["start"].FirstOrDefault();
			var length = Request.Form["length"].FirstOrDefault();
			var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
				.FirstOrDefault();
			var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
			var searchValue = Request.Form["search[value]"].FirstOrDefault();
			int pageSize = length != null ? Convert.ToInt32(length) : 0;
			int skip = start != null ? Convert.ToInt32(start) : 0;

			var request = new DatatableRequestModel
			{
				Draw = draw,
				Start = start,
				Length = length,
				SortColumn = sortColumn,
				SortColumnDirection = sortColumnDirection,
				SearchValue = searchValue,
				PageSize = pageSize,
				Skip = skip
			};

			return request;
		}
	}
}
