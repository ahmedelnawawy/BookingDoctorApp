using AppHost.Controllers;
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
                new SharedKernel.StartUp(Configuration),
                
            };
        }

        //Add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers()
                .AddApplicationPart(typeof(DAvailablityController).Assembly);
            services.AddControllers()
                .AddApplicationPart(typeof(AppointmentController).Assembly);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Inject Modules services
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
