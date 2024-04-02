using AmlBatchProcessor.Application.BatchItems.Events;
using AmlBatchProcessor.Domain.Entities;
using AmlBatchProcessor.Domain.Enum;
using MediatR;

namespace AmlBatchProcessor.Application.BatchItems.Commands
{
    public record CreateBatchItemCommand(Guid BatchFileId, string Data, BatchItemStatus Status) : IRequest<int>;

    public class CreateBatchItemCommandHandler : IRequestHandler<CreateBatchItemCommand, int>
    {
        public Task<int> Handle(CreateBatchItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new BatchItem(request.Data);

            entity.AddDomainEvent(new CreateBatchItemEvent(entity));

            //Add the event and savechanges

            return Task.FromResult(entity.Id);
        }
    }
}