using ProductMS.Shared;

namespace ProductMS.Features.Product
{
	public class ProductService : IProductService
	{
		private readonly IDapperService _dapperService;

		public ProductService(IDapperService dapperService)
		{
			_dapperService = dapperService;
		}

		public ProductViewModel? GetById(int id)
		{
			var query = "SELECT Id, Name, Price, Description, CreatedDate FROM Product WHERE Id = @id and IsDelete = 0;";
			var product = _dapperService.QueryFirstOrDefault<ProductViewModel>(query, new { id });

			return product;
		}

		public DatatableResponseModel<ProductViewModel> GetList(DatatableRequestModel request)
		{
			string orderByClause = !String.IsNullOrWhiteSpace(request.SortColumn)
				? $"ORDER BY  {request.SortColumn} {request.SortColumnDirection}"
				: "ORDER BY Id";
			string searchingClause = !String.IsNullOrWhiteSpace(request.SearchValue?.Trim())
				? "And Name LIKE '%'+@SearchValue+'%' OR Price LIKE '%'+@SearchValue+'%' OR Description LIKE '%'+@SearchValue+'%'"
				: "";

			string query = $@"
                SELECT Id, Name, Price, Description, CreatedDate 
                FROM Product 
                WHERE IsDelete = 0 
				{searchingClause}
                {orderByClause}
                OFFSET {request.Skip} ROWS
                FETCH NEXT {request.PageSize} ROWS ONLY;
            ";

			var dataList = _dapperService.Query<ProductViewModel>(query, request);

			var recordCountQuery = @$"SELECT COUNT(Id) FROM Product WHERE IsDelete = 0 {searchingClause}";
			var totalRecords = _dapperService.QueryFirstOrDefault<int>(recordCountQuery);

			var response = request.ChangeDatatableResponse(dataList, totalRecords);
			return response;
		}

		public int Save(ProductViewModel model)
		{
			var query = "INSERT INTO Product (Name, Price, Description, CreatedDate) VALUES (@name, @price, @description, GETDATE())";
			var result = _dapperService.Execute(query, model);
			return result;
		}

		public int Update(ProductViewModel model)
		{
			var query = "UPDATE Product SET Name = @name, Price = @price, Description = @description, UpdatedDate = GETDATE() WHERE id = @id and IsDelete = 0;";
			var result = _dapperService.Execute(query, model);
			return result;
		}

		public int Delete(int id)
		{
			var query = "UPDATE Product SET IsDelete = 1, UpdatedDate = GETDATE() WHERE id = @id";
			var result = _dapperService.Execute(query, id);
			return result;
		}

		public bool IsDuplicate(ProductViewModel model)
		{
			var query = model is { Id: > 0 }
				? "SELECT COUNT(Id) AS Count FROM Product WHERE Id <> @id and Name = @name and IsDelete = 0;"
				: "SELECT COUNT(Id) AS Count FROM Product WHERE Name = @name and IsDelete = 0;";

			var count = _dapperService
				.QueryFirstOrDefault<int>(query, new { id = model.Id, name = model.Name });

			return count > 0;
		}
	}
}
