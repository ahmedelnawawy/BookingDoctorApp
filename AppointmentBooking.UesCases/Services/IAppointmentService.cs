using AppointmentBooking.Core.Entities;

namespace AppointmentBooking.UesCases.Services
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointmentAsync(Guid slotRefId, Guid patientId);
        Task<Appointment?> GetAppointmentByIdAsync(Guid id);
        Task<List<Appointment>> GetAllAppointmentAsync();

        Task<Guid> CreateSlotRefAsync(SlotRef slot);
        Task<List<SlotRef>> GetAllSlotsAsync();
        Task<SlotRef?> GetSlotByIdAsync(Guid id);

        Task<Guid> CreatePatientAsync(string name);
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient?> GetPatientByIdAsync(Guid id);


    }
}
