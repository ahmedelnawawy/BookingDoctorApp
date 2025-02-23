﻿using AppintmentBooking.APIs.Controllers;
using Availability.APIs.Controllers;
using Shell.Controllers;
using IStartup = SharedKernel.Contract.IStartUp;
namespace BookingAppAPIs
{
    public class Startup
    {
        private List<IStartup> _assebmliesStartUp;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _assebmliesStartUp = new List<IStartup>
            {
                new Availability.APIs.StartUp(Configuration),
                new AppintmentBooking.APIs.StartUp(Configuration),
                new SharedKernel.StartUp(configuration),
                new AppointmentConfirmation.StartUp(Configuration),
                new Shell.StartUp(Configuration),

    };
        }

        //Add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            // Add modules Controllers 
            services.AddControllers()
                .AddApplicationPart(typeof(SlotController).Assembly);
            services.AddControllers()
                .AddApplicationPart(typeof(AppointmentController).Assembly);
            services.AddControllers()
                .AddApplicationPart(typeof(AppointmentManagementController).Assembly);


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // Inject Modules services Collections
            _assebmliesStartUp.ForEach(startUp => startUp.ConfigureServices(services));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();
            });

        }
    }
}
