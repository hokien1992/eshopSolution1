﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopSolution.Data.Entities
{
	// Config theo dạng Attribute
	//[Table("Products")]
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public decimal OriginalPrice { get; set; }
		public int Stock { get; set; }
		public int ViewCount { get; set; }
		// Config theo dạng Attribute
		//[Required]
		public DateTime DateCreated { get; set; }
		public string SeoAlias { get; set; }
		public List<ProductInCategory> ProductInCategories { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
