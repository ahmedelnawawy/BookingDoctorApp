using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;
using SharedKernel.EventBus;
using SharedKernel.EventBus.Infrastructure;

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
            var eventBus = new InMemoryEventBus();
            services.AddSingleton(eventBus);


        }
    }
}
