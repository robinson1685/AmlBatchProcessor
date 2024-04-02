namespace AmlBatchProcessor.Domain.Entities
{
    public class BatchFile : BaseAuditableEntity
    {
        public string FilePath { get; private set; }
        public BatchFileStatus Status { get; private set; }
        public List<BatchItem> BatchItems { get; private set; } = new List<BatchItem>();

        public BatchFile(string filePath)
        {
            FilePath = filePath;
            Status = BatchFileStatus.Pending;
        }

        public void MarkAsProcessed()
        {
            Status = BatchFileStatus.Processed;
        }
    }
}
