using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;

namespace AppointmentBooking.Infrastructure.Data
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private static readonly Dictionary<Guid, Appointment> _db = new();

        public Task<Appointment?> GetByIdAsync(Guid id)
        {
            _db.TryGetValue(id, out var appointment);
            return Task.FromResult(appointment);
        }

        public Task AddAsync(Appointment appointment)
        {
            _db[appointment.Id] = appointment;
            return Task.CompletedTask;
        }

        public Task<List<Appointment>> GetAllAsync()
        {
            return Task.FromResult(_db.Values.ToList());
        }
    }
}
