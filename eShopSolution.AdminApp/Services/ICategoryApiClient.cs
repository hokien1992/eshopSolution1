using eShopSolution.ViewModels.Catelog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Services
{
	public interface ICategoryApiClient
	{
		Task<List<CategoryVm>> GetAll(string languageId);
	}
}
