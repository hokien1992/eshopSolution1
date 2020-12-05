using eShopSolution.ViewModels.Catelog.ProductImages;
using eShopSolution.ViewModels.Catelog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catelog.Products
{
	public interface IProductService
	{
		Task<int> Create(ProductCreateRequest request);
		Task<int> Update(ProductUpdateRequest request);
		Task<int> Delete(int productId);
		Task<bool> UpdatePrice(int productId, decimal newPrice);
		Task<bool> UpdateStock(int productId, int addedQuantity);
		Task<ProductViewModel> GetById(int productId, string languageId); 
		Task AddViewCount(int productId);
		Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
		Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetManageProductPagingRequest request);

		Task<int> AddImage(int productId, ProductImageCreateRequest request);
		Task<int> RemoveImage(int imageId);
		Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
		Task<ProductImageViewModel> GetImageById(int imageId);
		Task<List<ProductImageViewModel>> GetListImages(int productId);

	}
}
