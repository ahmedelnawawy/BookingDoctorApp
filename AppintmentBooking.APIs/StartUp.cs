using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using AppointmentBooking.UesCases.EventHandlers;
using AppointmentBooking.UesCases.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using PatientBooking.Infrastructure.Data;
using SharedKernel.Contract;
using SharedKernel.EventBus.Infrastructure;
using SlotRefBooking.Infrastructure.Data;

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
            var slotCreatedEventHandler = new SlotCreatedEventHandler(services.BuildServiceProvider().GetRequiredService<IAppointmentService>());
            eventBus.Register(slotCreatedEventHandler);

            // Register infrastructure services
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISlotRefRepository, SlotRefRepository>();

            // Register application services
            services.AddScoped<IAppointmentService, AppointmentService>();


        }
    }
}
