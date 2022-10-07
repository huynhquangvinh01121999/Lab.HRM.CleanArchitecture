using Application.Behaviours;
using Application.Features.Employee.Commands.CreateEmployees;
using Application.Features.Employee.Queries.GetListEmployees;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace API.Extensions.ServiceExtensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationLayerExtension(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetListEmployeeHandler).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
