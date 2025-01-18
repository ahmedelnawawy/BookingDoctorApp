using AppointmentBooking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infrastructure.Data
{
    public class AppointmentBookingDbContext : DbContext
    {
        public AppointmentBookingDbContext(DbContextOptions<AppointmentBookingDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<SlotRef> SlotsRef { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasOne(o => o.Patient);
            modelBuilder.Entity<Appointment>().HasOne(o => o.SlotRef);
                        
        }
    }
}
