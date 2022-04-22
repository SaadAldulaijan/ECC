using Microsoft.Extensions.DependencyInjection;

namespace ECC.Shared.Installers
{
    public static class Extensions
    {
        public static IServiceCollection Install(this IServiceCollection services)
        {

            return services;
        }
    }
}