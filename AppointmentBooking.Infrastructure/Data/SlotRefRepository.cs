using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;

namespace SlotRefBooking.Infrastructure.Data
{
    public class SlotRefRepository : ISlotRefRepository
    {
        private readonly Dictionary<Guid, SlotRef> _db = new();

        public Task<SlotRef?> GetByIdAsync(Guid id)
        {
            _db.TryGetValue(id, out var slotRef);
            return Task.FromResult(slotRef);
        }

        public Task AddAsync(SlotRef slotRef)
        {
            _db[slotRef.Id] = slotRef;
            return Task.CompletedTask;
        }

        public Task<List<SlotRef>> GetAllAsync()
        {
            return Task.FromResult(_db.Values.ToList());
        }

        public Task<bool> IsExisitAndNotReservedAsync(Guid id)
        {
            _db.TryGetValue(id, out var slotRef);
            return Task.FromResult(slotRef is not null &&  !slotRef.IsReserved);
        }
    }
}
