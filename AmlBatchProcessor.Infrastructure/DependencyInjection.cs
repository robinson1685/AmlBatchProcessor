using AmlBatchProcessor.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AmlBatchProcessor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAmlBatchWorkerService, AmlBatchWorkerService>();
            services.Configure<FileWatcherSettings>(configuration.GetSection(nameof(FileWatcherSettings)));

            return services;
        }
    }
}
