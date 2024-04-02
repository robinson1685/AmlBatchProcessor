using AmlBatchProcessor.Domain.Common;
using AmlBatchProcessor.Domain.Exceptions;
namespace AmlBatchProcessor.Domain.Entities
{
    public sealed class BatchItem : BaseAuditableEntity
    {
        public Guid BatchFileId { get; set; }
        public string Data { get; set; }
        public BatchItemStatus? Status { get; set; }
        public ProcessingResult? Result { get; private set; }

        public BatchItem(string data)
        {
            Data = data;
            Status = BatchItemStatus.Pending;
            Result = null;
        }

        public void CheckAllFieldsWork(ProcessingResult result)
        {
            if(result.SetBatchItemId(BatchFileId)){
                throw new BatchItemIsNullDomainException($"{nameof(result)} is null.");
            }
        }
    }
}
