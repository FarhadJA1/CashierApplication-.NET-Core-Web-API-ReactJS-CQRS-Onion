using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace C.Service;
public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        
        return services;
    }
}
