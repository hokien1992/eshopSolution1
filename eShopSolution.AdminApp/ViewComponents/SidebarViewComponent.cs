using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.ViewComponents
{
	public class SidebarViewComponent : ViewComponent
	{
		public SidebarViewComponent() { 
			
		}
		public IViewComponentResult Invoke() {
			return View();
		}
	}
}
