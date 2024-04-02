using AmlBatchProcessor.Domain.Common;
using AmlBatchProcessor.Domain.Entities;

namespace AmlBatchProcessor.Application.BatchItems.Events
{
    public class CreateBatchItemEvent : BaseEvent
    {
        public CreateBatchItemEvent(BatchItem data)
        {
            Data = data;
        }

        public BatchItem Data { get; }
    }

}
