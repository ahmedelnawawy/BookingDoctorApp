using System;
namespace SharedKernel.EventBus.Contracts
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
