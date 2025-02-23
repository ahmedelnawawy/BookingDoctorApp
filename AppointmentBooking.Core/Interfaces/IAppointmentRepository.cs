﻿using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Appointment appointment);
        Task<List<Appointment>> GetAllAsync();
    }
}
