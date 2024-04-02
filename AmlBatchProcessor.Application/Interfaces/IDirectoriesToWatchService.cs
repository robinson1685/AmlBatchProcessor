namespace AmlBatchProcessor.Application.Interfaces
{
    public interface IDirectoriesToWatchService
    {
        ValueTask<string> GetDirectoryName(string path);
    }
}