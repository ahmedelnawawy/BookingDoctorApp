using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface ISlotRefRepository
    {
        Task<SlotRef?> GetByIdAsync(Guid id);
        Task<List<SlotRef>> GetAllAsync();
        Task AddAsync(SlotRef slot);
        Task<bool> IsExisitAndNotReservedAsync(Guid id);
    }
}
