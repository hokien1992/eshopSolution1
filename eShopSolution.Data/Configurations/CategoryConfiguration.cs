using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories");

			builder.HasKey("Id");

			builder.Property(x => x.Status).HasDefaultValue(Status.Active);

			builder.Property(x=>x.SortOrder).IsRequired().HasDefaultValue(0);

			builder.Property(x=>x.ParentId).IsRequired().HasDefaultValue(0);

			builder.Property(x => x.IsShowOnHome).HasDefaultValue(false);
		}
	}
}
