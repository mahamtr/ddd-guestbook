using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Extensions
{
    public static class AddAuthenticationExtension
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services,string issuer, string audience, string key)
        {
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			   .AddJwtBearer(options =>
			   {
				   options.TokenValidationParameters = new TokenValidationParameters
				   {
					   ValidateIssuer = true,
					   ValidateAudience = true,
					   ValidateLifetime = true,
					   ValidateIssuerSigningKey = true,
					   ValidIssuer = issuer,
					   ValidAudience = audience,
					   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
					   ClockSkew = TimeSpan.Zero
				   };
			   });
			return services;
		}
    }
}
