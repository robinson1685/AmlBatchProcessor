using AmlBatchProcessor.Domain.ValueObjects;

namespace AmlBatchProcessor.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(Email email);
    }
}
