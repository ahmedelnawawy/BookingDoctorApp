using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.UesCases.Services
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointmentAsync(Guid dAvailabilityRefId, Guid patientId, string patientName, DateTime reservedAt);
        Task<Appointment?> GetAppointmentByIdAsync(Guid id);
    }
}
