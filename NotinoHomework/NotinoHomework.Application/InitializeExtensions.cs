using Microsoft.Extensions.DependencyInjection;
using NotinoHomework.Application.Factories;
using NotinoHomework.Application.Factories.Interfaces;
using NotinoHomework.Application.Providers;
using NotinoHomework.Application.Services.Implementation;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application
{
    public static class InitializeExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IConvertorFactory, ConvertorFactory>();
            serviceCollection.AddScoped<FileProvider>();
            serviceCollection.AddScoped<JsonConvertorService>();
            serviceCollection.AddScoped<XmlConvertorService>();
            serviceCollection.AddScoped<IFileService, FileService>();

            return serviceCollection;
        }
    }
}
