using Microsoft.Extensions.DependencyInjection;

namespace IVersion
{
    public static class ServiceCollectionExtension
    {
        public static void AddIVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IVersion, Version>();
        }
    }
}
