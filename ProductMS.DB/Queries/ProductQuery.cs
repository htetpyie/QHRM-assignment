using ProductMS.Shared.Models;

namespace ProductMS.DB.Queries
{
	public class ProductQuery
	{
		public const string SELECT = "SELECT Id, Name, Price, Description, CreatedDate FROM Product WHERE Id = @id and IsDelete = 0;";
		public const string INSERT = "INSERT INTO Product (Name, Price, Description, CreatedDate) VALUES (@name, @price, @description, GETDATE())";
		public const string UPDATE = "UPDATE Product SET Name = @name, Price = @price, Description = @description, ModifiedDate = GETDATE() WHERE id = @id and IsDelete = 0;";
		public const string DELETE = "UPDATE Product SET IsDelete = 1, ModifiedDate = GETDATE() WHERE id = @id";
		public const string UPDATEDUPLICATE = "SELECT COUNT(Id) AS Count FROM Product WHERE Id <> @id and Name = @name and IsDelete = 0;";
		public const string CREATEDUPLICATE = "SELECT COUNT(Id) AS Count FROM Product WHERE Name = @name and IsDelete = 0;";

		#region Pagination Queries
		public static string GetPaginationQuery(DatatableRequestModel request)
		{
			string orderByClause = !String.IsNullOrWhiteSpace(request.SortColumn)
			? $"ORDER BY {request.SortColumn} {request.SortColumnDirection}"
			: "ORDER BY Id DESC";

			string query = $@"
                SELECT Id, Name, Price, Description, CreatedDate 
                FROM Product 
                WHERE IsDelete = 0 
				{SearchingClause(request)}
                {orderByClause}
                OFFSET @Skip ROWS
                FETCH NEXT @PageSize ROWS ONLY;
            ";

			return query;
		}

		public static string GetCountQuery(DatatableRequestModel request) =>
			@$"SELECT COUNT(Id) FROM Product WHERE IsDelete = 0 {SearchingClause(request)}";

		private static string SearchingClause(DatatableRequestModel request)
		{
			var searchValue = request.SearchValue?.Trim();
			string searchingClause = !String.IsNullOrWhiteSpace(searchValue)
				? $"AND (Name LIKE '%{searchValue}%' OR Price LIKE '%{searchValue}%' OR Description LIKE '%{searchValue}%')"
				: "";
			return searchingClause;
		}
		#endregion
	}
}
