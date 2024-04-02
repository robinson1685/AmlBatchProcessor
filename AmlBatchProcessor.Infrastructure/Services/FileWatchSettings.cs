using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlBatchProcessor.Infrastructure.Services
{
    public class FileWatcherSettings
    {
        public bool IncludeSubdirectories { get; set; }
        public List<string> DirectoriesToWatch { get; set; }

    }
}
