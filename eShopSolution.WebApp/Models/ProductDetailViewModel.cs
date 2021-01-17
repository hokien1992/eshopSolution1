using eShopSolution.ViewModels.Catelog.Categories;
using eShopSolution.ViewModels.Catelog.ProductImages;
using eShopSolution.ViewModels.Catelog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Models
{
	public class ProductDetailViewModel
	{
		public CategoryVm Category { get; set; }
		public ProductVm Product { get; set; }
		public List<ProductVm> RelatedProducts { get; set; }
		public List<ProductImageViewModel> MyProperty { get; set; }
	}
}
