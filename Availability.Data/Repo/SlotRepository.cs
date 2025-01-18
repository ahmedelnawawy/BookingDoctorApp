using Availability.Data.Contract;
using Availability.Domain;
using Microsoft.EntityFrameworkCore;

namespace Availability.Data.Repo
{
    public class SlotRepository : ISlotRepository
    {
        private readonly AvailabilityDbContext _context;
        public SlotRepository(AvailabilityDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Slot slot)
        {
            await _context.Slots.AddAsync(slot);
            await _context.SaveChangesAsync();
            return slot.Id;
        }

        public async Task<List<Slot>> GetAllSlotsAsync()
        {
            var slots = await _context.Slots.ToListAsync();
            return slots;
        }

        public async Task<Slot> GetByIdAsync(Guid id)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null)
            {
                throw new Exception("Handled in Infra . Not Found Slot");
            }
            return slot;
        }

        public async Task MarkeSlotAsReserved(Guid id, bool IsReserved)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null)
            {
                throw new Exception("Handled in Infra . Not Found Slot");
            }
            slot.MarkSlotAsReversed(IsReserved);
            await _context.SaveChangesAsync();
        }
    }
}
