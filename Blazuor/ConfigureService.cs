using Blazuor.Components.Dropdown;
using Microsoft.Extensions.DependencyInjection;

namespace Blazuor;

public static class ConfigureService
{
    public static IServiceCollection AddBlazuor(this IServiceCollection services)
    {
        services.AddScoped<BlazuorDropdownJsInterop>();

        return services;
    }
}
