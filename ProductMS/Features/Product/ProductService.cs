namespace ProductMS.Features.Product;

public class ProductService : IProductService
{
	private readonly IDapperService _dapperService;

	public ProductService(IDapperService dapperService)
	{
		_dapperService = dapperService;
	}

	public ProductViewModel? GetById(int id)
	{
		var query = ProductQuery.SELECT;
		var product = _dapperService.QueryFirstOrDefault<ProductViewModel>(query, new { id });
		return product;
	}

	public DatatableResponseModel<ProductViewModel> GetList(DatatableRequestModel request)
	{
		var query = ProductQuery.GetPaginationQuery(request);
		var dataList = _dapperService.Query<ProductViewModel>(query, request);

		var recordCountQuery = ProductQuery.GetCountQuery(request);
		var totalRecords = _dapperService.QueryFirstOrDefault<int>(recordCountQuery);

		var response = request.ChangeDatatableResponse(dataList, totalRecords);
		return response;
	}

	public int Save(ProductViewModel model)
	{
		var query = ProductQuery.INSERT;
		var result = _dapperService.Execute(query, model);
		return result;
	}

	public int Update(ProductViewModel model)
	{
		var query = ProductQuery.UPDATE;
		var result = _dapperService.Execute(query, model);
		return result;
	}

	public int Delete(int id)
	{
		var query = ProductQuery.DELETE;
		var result = _dapperService.Execute(query, new { id });
		return result;
	}

	public bool IsDuplicate(ProductViewModel model)
	{
		var query = model is { Id: > 0 }
			? ProductQuery.UPDATEDUPLICATE
			: ProductQuery.CREATEDUPLICATE;

		var count = _dapperService
			.QueryFirstOrDefault<int>(query, new { id = model.Id, name = model.Name });

		return count > 0;
	}
}
