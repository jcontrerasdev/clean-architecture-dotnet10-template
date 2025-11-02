using Microsoft.Extensions.DependencyInjection;

namespace Nanabills.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, string mediatorRLicenseKey)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            options.LicenseKey = mediatorRLicenseKey;
            // Example of adding pipeline behaviors
            //options.AddOpenBehavior(typeof(ValidationBehavior<,>));
            //options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
        });

        // Example of adding FluentValidation validators
        //services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}
