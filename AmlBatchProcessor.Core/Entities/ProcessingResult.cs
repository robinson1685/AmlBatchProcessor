using AmlBatchProcessor.Domain.Exceptions;

namespace AmlBatchProcessor.Domain.Entities
{

    public sealed class ProcessingResult
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid BatchItemId { get; private set; }
        public string TransformedData { get; private set; }
        public ApiResponse ApiResponse { get; private set; }

        public ProcessingResult(string transformedData, ApiResponse apiResponse)
        {
            TransformedData = transformedData;
            ApiResponse = apiResponse;
        }

        public bool SetBatchItemId(Guid batchItemId)
        {
            if(batchItemId == Guid.Empty)
            {
                throw new SetBatchItemIdIsNullDomainException($"{nameof(batchItemId)} is empty.");
            }

            return true;
        }
    }
}
