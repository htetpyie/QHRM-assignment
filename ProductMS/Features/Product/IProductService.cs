
namespace ProductMS.Features.Product
{
	public interface IProductService
	{
		int Delete(int id);
		ProductViewModel? GetById(int id);
		DatatableResponseModel<ProductViewModel> GetList(DatatableRequestModel request);
		bool IsDuplicate(ProductViewModel model);
		int Save(ProductViewModel model);
		int Update(ProductViewModel model);
	}
}