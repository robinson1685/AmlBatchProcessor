namespace AmlBatchProcessor.Infrastructure.Services
{
    internal class EmailService(ILogger<EmailService> _logger) : IEmailService
    {
        public Task SendEmail(Email email)
        {
            _logger.LogInformation($"Not actually sending an email to {email.To} from {email.From} with subject {email.Subject} and body {email.Body}");
            return Task.CompletedTask;
        }
    }
}