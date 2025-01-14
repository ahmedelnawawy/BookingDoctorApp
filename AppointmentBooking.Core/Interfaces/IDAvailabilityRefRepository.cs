using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface IDAvailabilityRepository
    {
        Task<DAvailabilityRef?> GetByIdAsync(Guid id);
        Task AddAsync(DAvailabilityRef customer);
    }
}
