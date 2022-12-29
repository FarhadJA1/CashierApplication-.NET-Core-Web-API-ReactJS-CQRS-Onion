using C.Service.Mappings;
using C.Service.Services.Implementations;
using C.Service.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace C.Service;
public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IMeasureUnitService, MeasureUnitService>();
        return services;
    }

    public static IServiceCollection SendAssemblyToMediatr(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(assembly);
    }
}
