using eShopSolution.ViewModels.Catelog.Categories;
using eShopSolution.ViewModels.Catelog.Products;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Models
{
	public class ProductCategoryViewModel
	{
		public CategoryVm Category { get; set; }

		public PagedResult<ProductVm> Products { get; set; }
	}
}
