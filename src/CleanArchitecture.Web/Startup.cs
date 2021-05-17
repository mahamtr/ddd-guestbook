using CleanArchitecture.Infrastructure;
using CleanArchitecture.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;


namespace CleanArchitecture.Web
{
	public class Startup
	{
		public Startup(IConfiguration config) => this.Configuration = config;

		public IConfiguration Configuration { get; }

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

            services.AddDbContext(Configuration);

			services.AddControllersWithViews();
			services.AddRazorPages();
			services.ConfigureAuthentication(Configuration["Jwt:Issuer"], Configuration["JWT:Audience"], Configuration["Jwt:Key"]);

			services.ConfigureSwagger();


			services.AddMediatR(Assembly.GetExecutingAssembly());

			return ContainerSetup.InitializeWeb(Assembly.GetExecutingAssembly(), services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.EnvironmentName == "Development")
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseExceptionHandler(c => c.Run(async context =>
			{
				var exception = context.Features
					.Get<IExceptionHandlerPathFeature>()
					.Error;
				var response = new { error = exception.Message };
				await context.Response.WriteAsJsonAsync(response);
			}));

			app.UseRouting();

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger();

			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
				
				});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});
		}
	}
}
