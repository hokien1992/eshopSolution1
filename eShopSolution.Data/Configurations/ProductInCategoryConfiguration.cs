using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
	public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
	{
		public void Configure(EntityTypeBuilder<ProductInCategory> builder)
		{
			builder.ToTable("ProductIncategories");
			builder.HasKey(x => new { x.ProductId, x.CategoryId });
			builder.HasOne(x => x.Product).WithMany(pc => pc.ProductInCategories)
				.HasForeignKey(pId=>pId.ProductId);
			builder.HasOne(x => x.Category).WithMany(pc => pc.ProductIncategories)
				.HasForeignKey(cId => cId.CategoryId);
		}
	}
}
