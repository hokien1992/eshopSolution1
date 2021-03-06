using eShopSolution.ApiIntegration;
using eShopSolution.WebApp.LocalizationResources;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;

namespace eShopSolution.WebApp
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
			services.AddHttpClient();
			// add multiple language
			var cultures = new[]
			{
				new CultureInfo("vi"),
				new CultureInfo("en")
			};
			// end add language 
			services.AddControllersWithViews().AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(ops =>
			{
				// When using all the culture providers, the localization process will
				// check all available culture providers in order to detect the request culture.
				// If the request culture is found it will stop checking and do localization accordingly.
				// If the request culture is not found it will check the next provider by order.
				// If no culture is detected the default culture will be used.

				// Checking order for request culture:
				// 1) RouteSegmentCultureProvider
				//      e.g. http://localhost:1234/tr
				// 2) QueryStringCultureProvider
				//      e.g. http://localhost:1234/?culture=tr
				// 3) CookieCultureProvider
				//      Determines the culture information for a request via the value of a cookie.
				// 4) AcceptedLanguageHeaderRequestCultureProvider
				//      Determines the culture information for a request via the value of the Accept-Language header.
				//      See the browsers language settings

				// Uncomment and set to true to use only route culture provider
				ops.UseAllCultureProviders = false;
				ops.ResourcesPath = "LocalizationResources";
				ops.RequestLocalizationOptions = o =>
				{
					o.SupportedCultures = cultures;
					o.SupportedUICultures = cultures;
					o.DefaultRequestCulture = new RequestCulture("vi");
				};
			}); ;
			IMvcBuilder builder = services.AddRazorPages();
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			if (environment == Environments.Development)
			{
				builder.AddRazorRuntimeCompilation();
			}
			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
			});
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddTransient<ISlideApiClient, SlideApiClient>();
			services.AddTransient<IProductApiClient, ProductApiClient>();
			services.AddTransient<ICategoryApiClient, CategoryApiClient>();
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

			app.UseSession();

			app.UseRequestLocalization();

			app.UseEndpoints(endpoints =>
			{
				#region Url Page Detail Product
				endpoints.MapControllerRoute(
					name: "Detail Product en",
					pattern: "{culture}/product/{id}", new
					{
						controller = "Product",
						action = "Detail"
					});
				endpoints.MapControllerRoute(
					name: "Detail Product vi",
					pattern: "{culture}/{san-pham}/{id}", new
					{
						controller = "Product",
						action = "Detail"
					});
				#endregion
				#region Url List Category Product
				endpoints.MapControllerRoute(
					name: "Category en",
					pattern: "{culture}/categories/{id}", new
					{
						controller = "Product",
						action = "Category"
					});
				endpoints.MapControllerRoute(
					name: "Category vi",
					pattern: "{culture}/danh-muc/{id}", new
					{
						controller = "Product",
						action = "Category"
					});
				#endregion
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
