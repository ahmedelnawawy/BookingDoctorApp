using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(Guid id);
        Task<List<Patient>> GetAllAsync();
        Task<Guid> AddAsync(Patient patient);
    }
}
