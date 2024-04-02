using Ardalis.GuardClauses;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading;

namespace AmlBatchProcessor.Infrastructure.Services
{
    public class FileWatcherService : IFileWatcherService
    {
        private readonly ILogger<FileWatcherService> _logger;
        private FileSystemWatcher _fileSystemWatcher;
        private readonly FileWatcherSettings  _settings;
        private List<FileSystemWatcher> _fileSystemWatchers = new List<FileSystemWatcher>();
        private HashSet<string> _createdFiles = new HashSet<string>();

        public FileWatcherService(ILogger<FileWatcherService> logger, IOptions<FileWatcherSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value; // get the settings from the IOptions wrapper
        }

        public async Task GetFiles()
        {
            Guard.Against.Null(_settings.DirectoriesToWatch);
            //foreach oop to iterate through directoriesToWatch and create a filesystemwatcher for each directory
            _logger.LogInformation("AmlBatchWorkerService running at: {time}", DateTimeOffset.Now);
            try
            {

                foreach (var directory in _settings.DirectoriesToWatch.ToList())
                {
                    _fileSystemWatcher = new FileSystemWatcher
                    {
                        Path = directory,
                        Filter = "*.*",
                        NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                        IncludeSubdirectories = true,
                        InternalBufferSize = 8192
                    };

                    _fileSystemWatcher.Created += OnCreated;
                    _fileSystemWatcher.EnableRaisingEvents = true;
                    _fileSystemWatchers.Add(_fileSystemWatcher);
                }

                await Task.Delay(TimeSpan.FromHours(1));
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(AmlBatchWorkerService)}.{nameof(GetFiles)} threw an exception.");
                throw;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (_createdFiles.Contains(e.FullPath))
            {
                // This file has already been processed, so ignore this event
                return;
            }

            _logger.LogInformation("A file was created: {name}", e.Name);

            // Add the file to the set of processed files
            _createdFiles.Add(e.FullPath);
        }
    }
}
