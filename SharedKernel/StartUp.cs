using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.Infrastructure;
using SharedKernel.Extention;

namespace SharedKernel
{
    public class StartUp : IStartUp
    {
        public IConfiguration confug { get; }

        public StartUp(IConfiguration configuration)
        {
            confug = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the event bus
            services.AddSingleton<IEventBus, InMemoryEventBus>();
            // Register the Handlers
            services.AddDomainEventHandlers();
        }
    }
}
