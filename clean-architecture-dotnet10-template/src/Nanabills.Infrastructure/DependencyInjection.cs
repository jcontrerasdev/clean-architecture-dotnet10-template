using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nanabills.Application.Common.Interfaces;
using Nanabills.Infrastructure.Common.Persistence;
using Nanabills.Infrastructure.Transactions.Persistence;

namespace Nanabills.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddPersistence();
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<NanabillsDbContext>(options =>
            options.UseSqlServer("Server=.;Database=NanabillsDb;Trusted_Connection=True;TrustServerCertificate=True;"));

        services.AddScoped<ITransactionRepository, TransactionsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<NanabillsDbContext>());

        return services;
    }
}
