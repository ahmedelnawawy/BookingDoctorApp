using System.Collections.Concurrent;
using SharedKernel.EventBus.Domain;

namespace SharedKernel.EventBus.Infrastructure
{
    public class InMemoryEventBus
    {
        private readonly ConcurrentDictionary<Type, List<object>> _handlers = new();


        public void Register<T>(IDomainEventHandler<T> handler) where T : IDomainEvent
        {
            var eventType = typeof(T);

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<object>();
            }

            _handlers[eventType].Add(handler);
        }

        public Task PublishAsync<T>(T domainEvent) where T : IDomainEvent
        {
            if (_handlers.TryGetValue(typeof(T), out var handlers))
            {
                var tasks = handlers
                    .Cast<IDomainEventHandler<T>>()
                    .Select(handler => handler.HandleAsync(domainEvent));

                return Task.WhenAll(tasks);
            }
            return Task.CompletedTask;
        }
    }
}
