using Serilog;
using AmlBatchProcessor.Worker;
using Microsoft.AspNetCore.Hosting;
using AmlBatchProcessor.Infrastructure;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting worker job");

var builder = Host.CreateDefaultBuilder(args)
    .UseSerilog((context, services, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(context.Configuration));

builder.ConfigureServices((hostContext, services) =>
{
    services.Scan(
        selector => selector
            .FromAssemblies(
                AmlBatchProcessor.Infrastructure.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
        .WithSingletonLifetime());

    services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(AmlBatchProcessor.Application.AssemblyReference).Assembly);
    });

    services.AddInfrastructure(hostContext.Configuration);

    var workerSettings = new WorkerSettings();
    hostContext.Configuration.Bind(nameof(WorkerSettings), workerSettings);
    services.AddSingleton(workerSettings);

    services.AddHostedService<Worker>();
});


var host = builder.Build();
host.Run();