﻿using eShopSolution.ApiIntegration;
using eShopSolution.ViewModels.Catelog.Products;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers
{
	public class ProductController : Controller
	{
		private IProductApiClient _productApiClient;
		private ICategoryApiClient _categoryApiClient;

		public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient) {
			_productApiClient = productApiClient;
			_categoryApiClient = categoryApiClient;
		}

		public async Task<IActionResult> Detail()
		{
			return View();
		}

		public async Task<IActionResult> Category(int id, string culture, int page = 1) 
		{
			var products = await _productApiClient.GetPagings(new GetManageProductPagingRequest()
			{ 
				CategoryId = id,
				PageIndex = page,
				LanguageId = culture
			});
			return View(new ProductCategoryViewModel() { 
				Category = await _categoryApiClient.GetById(culture, id),
				Products = products
			});
		}
	}
}
