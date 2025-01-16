using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface ISlotRefRepository
    {
        Task<SlotRef?> GetByIdAsync(Guid id);
        Task<List<SlotRef>> GetAllAsync();
        Task AddAsync(SlotRef slot);
        Task MarkeSlotAsReserved(Guid id, bool IsReserved);
        Task<bool> IsExisitAndNotReservedAsync(Guid id);
    }
}
