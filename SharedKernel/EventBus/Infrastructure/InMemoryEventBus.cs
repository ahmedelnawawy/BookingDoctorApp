using Microsoft.Extensions.DependencyInjection;
using SharedKernel.EventBus.Contracts;
using System.Collections.Concurrent;

namespace SharedKernel.EventBus.Infrastructure
{
    public class InMemoryEventBus : IEventBus
    {
        // this Solution Will use DI To Found Handlers of events then cash them to avoid resolved  them from DI Container 
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<Type, List<object?>> _handlerCache = new();

        public InMemoryEventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Publish<T>(T @event) where T : IDomainEvent
        {
            // Resolve and execute handlers within a scope
            using (var scope = _serviceProvider.CreateScope()) // Create a scope for resolving handlerTypes 
            {
                var eventType = typeof(T);

                if (!_handlerCache.TryGetValue(eventType, out var handlerInstances))
                {
                    // Get handlers for the event type directly from the service provider
                    handlerInstances = scope.ServiceProvider
                        .GetServices(typeof(IDomainEventHandler<T>))
                        .ToList();

                    // Cache the handler instances
                    _handlerCache.TryAdd(eventType, handlerInstances);
                }
                foreach (var handlerInstance in handlerInstances)
                {
                    if (handlerInstance is IDomainEventHandler<T> domainEventHandler)
                    {
                        // Execute the handler asynchronously
                        await domainEventHandler.HandleAsync(@event);
                    }
                    else
                    {
                        throw new InvalidCastException($"Handler {handlerInstance?.GetType()} is not of type {typeof(IDomainEventHandler<T>)}.");
                    }
                }
            }
        }
    }
}
