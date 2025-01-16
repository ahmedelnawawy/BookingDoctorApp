using Microsoft.Extensions.DependencyInjection;
using SharedKernel.EventBus.Contracts;

namespace SharedKernel.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainEventHandlers(this IServiceCollection services)
        {
            var handlerInterfaceType = typeof(IDomainEventHandler<>);

            // Scan the assembly for types implementing IDomainEventHandler<T>
            var handlers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType))
                .ToList();

            // Register each handler type
            foreach (var handler in handlers)
            {
                foreach (var @interface in handler.GetInterfaces()
                             .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType))
                {
                    services.AddTransient(@interface, handler);
                }
            }

            return services;
        }
    }
}
