using Availability.Application.Contract;
using Availability.Application.Services;
using Availability.Data.Contract;
using Availability.Data.Repo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;
using SharedKernel.EventBus.Infrastructure;

namespace Availability.Application
{
    public class StartUp : IStartUp
    {
        public IConfiguration confug { get; }

        public StartUp(IConfiguration configuration)
        {
            confug = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services, InMemoryEventBus eventBus)
        {
            // Register infrastructure services
            services.AddScoped<ISlotRepository, SlotRepository>();
            // Register application services
            services.AddScoped<ISlotService, SlotService>();
        }
    }
}
