using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Infrastructure.ServiceInterfaces.Hubs;
using WssApplication.Infrastructure.Services;
using WssApplication.Infrastructure.Services.Hubs;

namespace WssApplication.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<ICatalogHubService, CatalogHubService>()
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<IDivisionService, DivisionService>();
        }
    }
}
