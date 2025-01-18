using Availability.Application.Contract;
using Availability.Application.Services;
using Availability.Data;
using Availability.Data.Contract;
using Availability.Data.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;

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
            //// Module Database
            services.AddDbContext<AvailabilityDbContext>(options =>
                options.UseSqlServer(confug.GetConnectionString("DoctorAvailabilityDB")), ServiceLifetime.Scoped);

            // Register infrastructure services
            services.AddScoped<ISlotRepository, SlotRepository>();
            // Register application services
            services.AddScoped<ISlotService, SlotService>();
        }
    }
}
