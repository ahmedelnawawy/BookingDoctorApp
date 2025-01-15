using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<List<Appointment>> GetAllAsync();
        Task AddAsync(Appointment customer);
    }
}
