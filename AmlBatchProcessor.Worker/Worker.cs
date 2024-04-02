using AmlBatchProcessor.Application.Interfaces;
using System.Runtime;

namespace AmlBatchProcessor.Worker
{
    public class Worker(ILogger<Worker> _logger, 
        IAmlBatchWorkerService _amlBatchWorkerService, WorkerSettings _settings)
        : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("AmlBatchProcessor.Worker service starting at: {time}", DateTimeOffset.Now);
            while (!stoppingToken.IsCancellationRequested)
            {
                await _amlBatchWorkerService.ExecuteAsync();
                await Task.Delay(_settings.DelayMilliseconds, stoppingToken);
            }
            _logger.LogInformation("AmlBatchProcessor.Worker service stopping at: {time}", DateTimeOffset.Now);
        }
    }
}
