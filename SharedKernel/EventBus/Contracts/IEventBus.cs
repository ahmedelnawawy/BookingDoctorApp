
namespace SharedKernel.EventBus.Contracts
{
    public interface IEventBus
    {
        Task Publish<T>(T @event) where T : IDomainEvent;
        //Task Register<T>(IDomainEventHandler<T> handler) where T : IDomainEvent;
    }
}
