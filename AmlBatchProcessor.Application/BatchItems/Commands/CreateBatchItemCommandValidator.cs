using FluentValidation;

namespace AmlBatchProcessor.Application.BatchItems.Commands
{
    public class CreateBatchItemCommandValidator : AbstractValidator<CreateBatchItemCommand>
    {
        public CreateBatchItemCommandValidator()
        {
            RuleFor(v => v.Data)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}