using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using AppointmentBooking.UesCases.EventHandlers;
using AppointmentBooking.UesCases.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using SharedKernel.Contract;
using SharedKernel.EventBus.Infrastructure;

namespace AppintmentBooking.APIs
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
            // Register event Handlers
            eventBus.Register(new SlotCreatedEventHandler());

            // Register infrastructure services
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            // Register application services
            services.AddScoped<IAppointmentService, AppointmentService>();


        }
    }
}
