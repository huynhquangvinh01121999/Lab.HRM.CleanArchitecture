using API.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Middleware;
using API.Extensions.ServiceExtensions;
using API.Extensions.ApplicationBuilderExtensions;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Application.Features.Employee.Queries.GetListEmployees;
using MediatR;
using System;
using System.Reflection;

namespace API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // register api version
            services.AddApiVersioningExtension();

            // register Swagger
            services.AddSwaggerServiceExtensions();

            // register Cors for localhost:3000
            services.AddCorsServiceExtensions();

            services.AddDbContext<LabContext>(options => options.UseSqlServer(_configuration.GetConnectionString("Default")));

            // register Identity
            services.AddIdentityServiceExtensions();

            // register Authentication service
            services.AddAuthenticateServiceExtensions(_configuration);

            // register DI
            services.AddDependencyInjectionExtensions();

            services.AddApplicationLayerExtension();

            // register signalR
            services.AddSignalR();

            // kiểm tra sức khỏe cho project
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR.Lab-API v1");
                });
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseHttpResponseExtensions();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Chathub>("/chat");
            });

        }
    }
}
