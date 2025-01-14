using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;

namespace AppointmentBooking.UesCases.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateAppointmentAsync(Guid dAvailabilityRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            var appointment = new Appointment(dAvailabilityRefId,patientId,patientName,reservedAt);
            await _repository.AddAsync(appointment);
            return appointment.Id;
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
