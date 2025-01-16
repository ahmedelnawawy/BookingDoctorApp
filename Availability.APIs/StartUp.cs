using AppointmentBooking.UesCases.EventHandlers;
using Availability.Application.Contract;
using Availability.Application.Services;
using Availability.Data.Contract;
using Availability.Data.Repo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;
using SharedKernel.EventBus.Contracts;

namespace Availability.APIs
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
            //// Automatically register all event handlers in the assembly
            //var assembly = typeof(ReserveSlotEventHandler).Assembly;
            //foreach (var type in assembly.GetTypes()
            //         .Where(t => t.GetInterfaces()
            //             .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>))))
            //{
            //    services.AddScoped(type);
            //}

            // Register infrastructure services
            services.AddScoped<ISlotRepository, SlotRepository>();
            // Register application services
            services.AddScoped<ISlotService, SlotService>();
        }
    }
}
