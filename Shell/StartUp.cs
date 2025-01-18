using Core.InPorts;
using Core.OutPorts;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Contract;
using Shell.Data;
using Shell.Repositories;

namespace Shell
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
            services.AddDbContext<AppointmentManagementDbContext>(options =>
                options.UseSqlServer(confug.GetConnectionString("AppointmentManagementDB")), ServiceLifetime.Scoped);

            // Register infrastructure services
            services.AddScoped<IDAppointmentRepository, DAppointmentRepository>();
            // Register application services
            services.AddScoped<IManagementService, ManagementService>();
        }
    }
}
