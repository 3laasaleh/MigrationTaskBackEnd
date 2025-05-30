using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Migration_Task.Confiqurations
{
    public static class ServicesConfiguration
    {

        public static void ConfigureCrosConfiguration(this IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy("*", builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());

            });


        }

        public static void JWTConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            // configure jwt authentication
            var appSettings = Configuration.GetValue<string>("secret");
            var key = Encoding.ASCII.GetBytes(appSettings);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero // Remove delay of token when expire


                };
            });

        }
    }

}
