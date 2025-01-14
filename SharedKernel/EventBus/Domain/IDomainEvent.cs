using System;
namespace SharedKernel.EventBus.Domain
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
