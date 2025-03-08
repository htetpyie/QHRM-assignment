namespace ProductMS.Features.Product
{
	public class ProductDataModel
	{
		public int Id { get; set; }
		public required string ProductName { get; set; }
		public required decimal Price { get; set; }
		public string? Description { get; set; }
		public bool IsDelete { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
