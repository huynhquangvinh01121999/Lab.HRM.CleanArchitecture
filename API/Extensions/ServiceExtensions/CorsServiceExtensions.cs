using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.ServiceExtensions
{
    public static class CorsServiceExtensions
    {
        public static IServiceCollection AddCorsServiceExtensions(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000")
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
