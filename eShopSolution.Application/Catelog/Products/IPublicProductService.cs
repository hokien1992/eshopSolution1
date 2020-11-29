using eShopSolution.ViewModels.Catelog.Products;
using eShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catelog.Products
{
	public interface IPublicProductService
	{
		Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
	}
}
