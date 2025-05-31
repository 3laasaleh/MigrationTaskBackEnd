using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MigrationTask.Data.IdentityContext;
using System.Text;

namespace Migration_Task.Confiqurations
{
    public static class ServicesConfiguration
    {

        public static void AddCrosConfiguration(this IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy("*", builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());

            });


        }

        public static void AddJwtIdentityConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            // configure jwt authentication
            // Add Identity (no UI needed)
            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);

            // Add JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

        }
    }

}
