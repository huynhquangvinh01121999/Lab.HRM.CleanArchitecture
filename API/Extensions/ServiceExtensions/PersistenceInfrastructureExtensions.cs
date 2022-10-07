using Domain.IRepositories;
using Domain.IRepositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.Base;

namespace API.Extensions.ServiceExtensions
{
    public static class PersistenceInfrastructureExtensions
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database Context
            services.AddDbContext<LabContext>(options => 
                                options.UseSqlServer(configuration.GetConnectionString("Default")));
            #endregion

            #region register repository dependency injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITitleNameRepository, TitleNameRepository>();
            services.AddTransient<IModeRepository, ModeRepository>();
            services.AddTransient<IRoleModeRepository, RoleModeRepository>();
            services.AddTransient<INotifyRepository, NotifyRepository>();
            services.AddTransient<IUserNotifyRepository, UserNotifyRepository>();
            #endregion

            return services;
        }
    }
}
