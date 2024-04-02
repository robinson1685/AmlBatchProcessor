namespace AmlBatchProcessor.Domain.Exceptions;

public sealed class SetBatchItemIdIsNullDomainException : Exception
{
    public SetBatchItemIdIsNullDomainException(string message)
          : base(message)
    {
    }
}
