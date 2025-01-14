using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using AppointmentBooking.UesCases.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;

namespace AppintmentBooking.APIs
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
            // Register infrastructure services
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            // Register application services
            services.AddScoped<IAppointmentService, AppointmentService>();


        }
    }
}
