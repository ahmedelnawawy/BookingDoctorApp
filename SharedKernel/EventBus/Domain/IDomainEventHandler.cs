namespace SharedKernel.EventBus.Domain
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}
