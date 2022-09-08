using Microsoft.Extensions.DependencyInjection;
using NotinoHomework.Application.Interfaces;
using NotinoHomework.Infrastructure.Repositories;

namespace NotinoHomework.Infrastructure
{
    public static class InitializeExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileRepository, FileRepository>();

            return serviceCollection;
        }
    }
}
