using Availability.Data.Contract;
using Availability.Domain;

namespace Availability.Data.Repo
{
    public class SlotRepository : ISlotRepository
    {
        private static readonly List<Slot> _Slot = new();

        public Task AddAsync(Slot slot)
        {
            _Slot.Add(slot);
            return Task.CompletedTask;
        }

        public Task<Slot?> GetByIdAsync(Guid id)
        {
            var slot = _Slot.Find(o => o.Id == id);
            return Task.FromResult(slot);
        }
    }
}
