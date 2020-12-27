using eShopSolution.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Components
{
	public class ListCategoriesViewComponent : ViewComponent
	{
        private readonly ICategoryApiClient _categoryApiClient;
        public ListCategoriesViewComponent(ICategoryApiClient categoryApiClient) {
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View("Default", items);
        }
    }
}
