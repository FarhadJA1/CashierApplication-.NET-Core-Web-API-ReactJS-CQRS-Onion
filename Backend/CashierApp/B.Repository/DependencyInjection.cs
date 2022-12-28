using B.Repository.Repositories.Implementations;
using B.Repository.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace B.Repository;
public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IMeasureUnitRepository, MeasureUnitRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
