using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Utilities.Constans
{
	public class SystemConstants
	{
		public const string mainConnectionString = "eShopSolutionDb";

		//public static string MainConnectionString { get; set; }
		public class AppSettings
		{
			public const string DefaultLanguageId = "DefaultLanguageId";
			public const string Token = "Token";
			public const string BaseAddress = "BaseAddress";
		}
		public class ProductSettings
		{
			public const int NumberOfFeaturedProducts = 4;
			public const int NumberOfLastestProducts = 6;
		}
		public class ProductContanst
		{
			public const string NA = "N/A";
		}
	}
}
