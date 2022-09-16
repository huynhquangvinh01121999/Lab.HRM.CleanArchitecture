using Domain.IRepositories;
using Domain.IRepositories.Base;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.Base;

namespace API.Extensions.ServiceExtensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjectionExtensions(this IServiceCollection services)
        {
            // register scoped for dependency injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITitleNameRepository, TitleNameRepository>();
            services.AddTransient<IModeRepository, ModeRepository>();
            services.AddTransient<IRoleModeRepository, RoleModeRepository>();
            services.AddTransient<INotifyRepository, NotifyRepository>();
            services.AddTransient<IUserNotifyRepository, UserNotifyRepository>();

            return services;
        }
    }
}
