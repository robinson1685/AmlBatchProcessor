using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmlBatchProcessor.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public string To { get; private set; }
        public string From { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public Email(string to, string from, string subject, string body)
        {
            To = to;
            From = from;
            Subject = subject;
            Body = body;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
