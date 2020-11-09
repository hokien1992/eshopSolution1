using eShopSolution.Data.Configurations;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.EF
{
	public class EShopDbContext : DbContext
	{
		public EShopDbContext(DbContextOptions options) : base(options) {

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
			//base.OnModelCreating(modelBuilder);
		}
		public DbSet<AppConfig> AppConfigs { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductInCategory> ProductIncategories { get; set; }
		public DbSet<Order> Order { get; set; }
	}
}
