using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlBatchProcessor.Domain.Exceptions
{
    public sealed class BatchItemIsNullDomainException : Exception
    {
        public BatchItemIsNullDomainException(string message)
              : base(message)
        {
        }
    }
}
