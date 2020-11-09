using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders");
			builder.HasKey(x=>x.Id);
			builder.Property(x=>x.UserId).HasDefaultValue(0);
			builder.Property(x=>x.Status).HasDefaultValue(OrderStatus.InProgress);
		}
	}
}
