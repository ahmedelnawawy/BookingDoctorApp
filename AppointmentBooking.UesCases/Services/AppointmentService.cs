using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;
using SharedKernel.EventBus.DomainEvents;
using SharedKernel.EventBus.Infrastructure;

namespace AppointmentBooking.UesCases.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly IPatientRepository _Patientrepository;
        private readonly ISlotRefRepository _SlotRefrepository;

        private readonly InMemoryEventBus _eventBus;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientrepository, 
            ISlotRefRepository slotRefrepository, InMemoryEventBus eventBus)
        {
            _AppointmentRepository = appointmentRepository;
            _Patientrepository = patientrepository;
            _SlotRefrepository = slotRefrepository;
            _eventBus = eventBus;
        }


        #region Appointment
        public async Task<Guid> CreateAppointmentAsync(Guid slotRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            bool IsExisitAndNotReserved = await _SlotRefrepository.IsExisitAndNotReservedAsync(slotRefId);
            if (!IsExisitAndNotReserved)
            {
                throw new Exception("Slot is not exisit or maybe reserved"); 
            }
            var appointment = new Appointment(slotRefId,patientId,patientName,reservedAt);
            await _AppointmentRepository.AddAsync(appointment);

            //Publish ReserveSlot
            var @event = new ReserveSlotEvent(slotRefId,true);
            await _eventBus.PublishAsync(@event);

            return appointment.Id;
        }

        public async Task<List<Appointment>> GetAllAppointmentAsync()
        {
            return await _AppointmentRepository.GetAllAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(Guid id)
        {
            return await _AppointmentRepository.GetByIdAsync(id);
        }
        #endregion

        #region Slots
        public async Task<Guid> CreateSlotRefAsync(SlotRef slot)
        {
              await _SlotRefrepository.AddAsync(slot);

            return slot.Id;
        }

        public async Task<List<SlotRef>> GetAllSlotsAsync()
        {
            return await _SlotRefrepository.GetAllAsync();
        }

        public async Task<SlotRef?> GetSlotByIdAsync(Guid id)
        {
            return await _SlotRefrepository.GetByIdAsync(id);
        }
        #endregion

        #region Patients
        public async Task<Guid> CreatePatientAsync(Patient patient)
        {
            await _Patientrepository.AddAsync(patient);

            return patient.Id;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _Patientrepository.GetAllAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(Guid id)
        {
            return await _Patientrepository.GetByIdAsync(id);
        }
        #endregion
    }
}
