﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catelog.Products
{
	public class ProductUpdateRequest
	{
		public int Id { get; set; }
		public string Name { set; get; }
		public string Description { set; get; }
		public bool? IsFeatured { get; set; }
		public string Details { set; get; }
		public string SeoDescription { set; get; }
		public string SeoTitle { set; get; }

		public string SeoAlias { get; set; }
		public string LanguageId { set; get; }
		public IFormFile ThumbnailImage { get; set; }
	}
}
