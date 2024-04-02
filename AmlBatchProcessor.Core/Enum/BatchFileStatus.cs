using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlBatchProcessor.Domain.Enum
{
    public enum BatchFileStatus
    {
        Pending,
        Processing,
        Processed,
        Failed
    }
}
