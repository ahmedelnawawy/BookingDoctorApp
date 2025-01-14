using Availability.Application.Dtos;
using Availability.Domain;

namespace Availability.Application.Contract
{
    public interface ISlotService
    {
        Task<Guid> CreateSlotAsync(SlotDto CreateRequest);
        Task<Slot?> GetSlotAsync(Guid id);
    }
}
