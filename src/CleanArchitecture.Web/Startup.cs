using CleanArchitecture.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text;

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

            services.AddControllersWithViews().AddNewtonsoftJson();
			services.AddRazorPages();
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
						   .AddJwtBearer(options =>
						   {
							   options.TokenValidationParameters = new TokenValidationParameters
							   {
								   ValidateIssuer = true,
								   ValidateAudience = true,
								   ValidateLifetime = true,
								   ValidateIssuerSigningKey = true,
								   ValidIssuer = Configuration["Jwt:Issuer"],
								   ValidAudience = Configuration["JWT:Audience"],
								   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
								   ClockSkew = TimeSpan.Zero
							   };
						   });

			services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }));
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

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
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
