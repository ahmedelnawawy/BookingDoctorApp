using Availability.Domain;

namespace Availability.Data.Contract
{
    public interface ISlotRepository
    {
        Task AddAsync(Slot order);
        Task<Slot?> GetByIdAsync(Guid id);
    }
}
