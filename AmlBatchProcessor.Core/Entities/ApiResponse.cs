namespace AmlBatchProcessor.Domain.Entities
{
    public class ApiResponse
    {
        public string ResponseData { get; private set; }
        public DateTime ReceivedAt { get; private set; } = DateTime.UtcNow;

        public ApiResponse(string responseData)
        {
            ResponseData = responseData;
        }
    }
}
