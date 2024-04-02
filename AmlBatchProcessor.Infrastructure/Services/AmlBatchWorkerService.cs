using AmlBatchProcessor.Application.BatchItems.Commands;
using AmlBatchProcessor.Domain.Enum;
using MediatR;

namespace AmlBatchProcessor.Infrastructure.Services
{
    public class AmlBatchWorkerService(ILogger<AmlBatchWorkerService> _logger, ISender sender, IFileWatcherService _fileWatcherService)
        : IAmlBatchWorkerService
    {
        public Task ExecuteAsync()
        {
            _logger.LogInformation("AmlBatchWorkerService running at: {time}", DateTimeOffset.Now);
            try
            {

                _logger.LogInformation("Task started running");

                _fileWatcherService.GetFiles();
                //var command = new CreateBatchItemCommand(Guid.NewGuid(), "Data", BatchItemStatus.Pending);

                //sender.Send(command);


                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(AmlBatchWorkerService)}.{nameof(ExecuteAsync)} threw an exception.");
                throw;
            }
        }
    }
}
