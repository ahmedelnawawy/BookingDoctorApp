using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infrastructure.Repo
{
    public class SlotRefRepository : ISlotRefRepository
    {
        private readonly AppointmentBookingDbContext _context;
        public SlotRefRepository(AppointmentBookingDbContext context)
        {
            _context = context;
        }

        public async Task<SlotRef?> GetByIdAsync(Guid id)
        {
            var slotRef = await _context.SlotsRef.FindAsync(id);
            return slotRef;
        }

        public async Task<Guid> AddAsync(SlotRef slotRef)
        {
            var item = await _context.SlotsRef.AddAsync(slotRef);
            await _context.SaveChangesAsync();

            return slotRef.Id;
        }

        public async Task<List<SlotRef>> GetAllAsync()
        {
            var appointments = await _context.SlotsRef.ToListAsync();
            return appointments;
        }

        public async Task MarkeSlotAsReserved(Guid id, bool IsReserved)
        {
            var slotRef = await _context.SlotsRef.FindAsync(id);
            slotRef?.MarkSlotAsReversed(IsReserved);
            await _context.SaveChangesAsync();
        }
    }
}
