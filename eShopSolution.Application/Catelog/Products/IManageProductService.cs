﻿using eShopSolution.Application.Catelog.Products.Dtos;
using eShopSolution.Application.Catelog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catelog.Products
{
	public interface IManageProductService
	{
		Task<int> Create(ProductCreateRequest request);
		Task<int> Update(ProductUpdateRequest request);
		Task<int> Delete(int productId);
		Task<bool> UpdatePrice(int productId, decimal newPrice);
		Task<bool> UpdateStock(int productId, int addedQuantity);
		Task AddViewCount(int productId);

		Task<List<ProductViewModel>> GetAll();
		Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
	}
}