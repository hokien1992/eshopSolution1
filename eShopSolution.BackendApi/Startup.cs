using eShopSolution.Application.Catelog.Products;
using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Constans;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<EShopDbContext>(options =>
		options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.mainConnectionString)));
			services.AddIdentity<AppUser, AppRole>()
				.AddEntityFrameworkStores<EShopDbContext>()
				.AddDefaultTokenProviders();
			//Declare DI
			services.AddTransient<IStorageService, FileStorageService>();
			services.AddTransient<IManageProductService, ManageProductService>();
			services.AddTransient<IPublicProductService, PublicProductService>();
			services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
			services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
			services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
			services.AddTransient<IUserService, UserService>();

			services.AddControllersWithViews();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger eShop Solution", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			// add swagger
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger eShop Solution V1");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
