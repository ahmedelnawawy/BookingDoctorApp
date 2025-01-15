using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface IDAvailabilityRepository
    {
        Task<SlotRef?> GetByIdAsync(Guid id);
        Task AddAsync(SlotRef slot);
        Task<bool> IsExisitAsync(Guid id);
    }
}
