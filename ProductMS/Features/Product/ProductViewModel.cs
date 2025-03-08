namespace ProductMS.Features.Product;

public class ProductViewModel
{
	public int Id { get; set; }
	public required string ProductName { get; set; }
	public required decimal Price { get; set; }
	public string? Description { get; set; }
}
