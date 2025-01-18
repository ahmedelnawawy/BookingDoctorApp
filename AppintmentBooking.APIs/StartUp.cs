using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using AppointmentBooking.Infrastructure.Repo;
using AppointmentBooking.UesCases.Services;
using Microsoft.EntityFrameworkCore;
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
            //// Module Database
            services.AddDbContext<AppointmentBookingDbContext>(options =>
                options.UseSqlServer(confug.GetConnectionString("AppointmentBookingDB")), ServiceLifetime.Scoped);

            // Register infrastructure services
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISlotRefRepository, SlotRefRepository>();
            // Register application services
            services.AddScoped<IAppointmentService, AppointmentService>();
        }
    }
}
