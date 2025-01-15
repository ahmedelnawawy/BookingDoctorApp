using Availability.Domain;

namespace Availability.Data.Contract
{
    public interface ISlotRepository
    {
        Task AddAsync(Slot order);
        Task MarkeSlotAsReserved(Guid id, bool IsReserved);  // I will pass the Is Reserved Beacuse maybe later use it in reverse Dir.
        Task<Slot?> GetByIdAsync(Guid id);
        Task<List<Slot>> GetAllSlotsAsync();
    }
}
