﻿using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface ISlotRefRepository
    {
        Task<SlotRef?> GetByIdAsync(Guid id);
        Task<List<SlotRef>> GetAllAsync();
        Task<Guid> AddAsync(SlotRef slotRef);
        Task MarkeSlotAsReserved(Guid id, bool IsReserved);
    }
}
