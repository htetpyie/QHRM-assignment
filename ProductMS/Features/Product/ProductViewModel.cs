using System.ComponentModel.DataAnnotations;

namespace ProductMS.Features.Product;

public class ProductViewModel
{
	public int Id { get; set; }

	[Required]
	[RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Special characters are not allowed.")]
	[StringLength(200)]
	[MaxLength(50)]
	public string? Name { get; set; }

	[Required]
	[DataType(DataType.Currency)]
	[Range(.01, 99999999.99)]
	//[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
	public decimal? Price { get; set; }
	public string? PriceString => Price?.ToString("N2");

	public DateTime CreatedDate { get; set; }
	public string CreatedDateString => CreatedDate.ToString("MMM dd yyyy, hh:mm tt");

	[StringLength(200)]
	[MaxLength(200)]
	public string? Description { get; set; }
}
