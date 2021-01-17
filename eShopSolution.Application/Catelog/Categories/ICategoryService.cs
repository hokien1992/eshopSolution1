using eShopSolution.ViewModels.Catelog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catelog.Categories
{
	public interface ICategoryService
	{
		Task<List<CategoryVm>> GetAll(string languageId);

		Task<CategoryVm> GetById(string languageId, int id);
	}
}
