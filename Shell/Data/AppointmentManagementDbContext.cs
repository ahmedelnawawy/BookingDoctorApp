using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Shell.Data
{
    public class AppointmentManagementDbContext : DbContext
    {
        public AppointmentManagementDbContext(DbContextOptions<AppointmentManagementDbContext> options) : base(options) { }

        public DbSet<DAppointment> DAppointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
