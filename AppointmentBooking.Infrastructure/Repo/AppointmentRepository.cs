using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infrastructure.Repo
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentBookingDbContext _context;

        public AppointmentRepository(AppointmentBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return appointment;
        }

        public async Task<Guid> AddAsync(Appointment appointment)
        {
            var item = await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }
    }
}
