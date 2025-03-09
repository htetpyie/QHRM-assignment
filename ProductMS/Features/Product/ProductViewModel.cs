using System.ComponentModel.DataAnnotations;

namespace ProductMS.Features.Product;

public class ProductViewModel
{
	public int Id { get; set; }

	[Required]
	public required string Name { get; set; }

	[Required]
	[Range(.01, 99999999.99)]
	public required decimal Price { get; set; }
	public string PriceString => Price.ToString("N2");

	public DateTime CreatedDate { get; set; }
	public string CreatedDateString => CreatedDate.ToString("MMM dd yyyy, hh:mm tt");

	[StringLength(300)]
	public string? Description { get; set; }
}
