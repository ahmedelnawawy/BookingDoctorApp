﻿using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.UesCases.Exceptions;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.DomainEvents;

namespace AppointmentBooking.UesCases.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        private readonly IPatientRepository _Patientrepository;
        private readonly ISlotRefRepository _SlotRefrepository;

        private readonly IEventBus _eventBus;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientrepository,
            ISlotRefRepository slotRefrepository, IEventBus eventBus)
        {
            _AppointmentRepository = appointmentRepository;
            _Patientrepository = patientrepository;
            _SlotRefrepository = slotRefrepository;
            _eventBus = eventBus;
        }


        #region Appointment
        public async Task<Guid> CreateAppointmentAsync(Guid slotRefId, Guid patientId)
        {

            var slot = await _SlotRefrepository.GetByIdAsync(slotRefId);

            if (slot is null || slot.IsReserved)
            {
                throw new CreateAppointmentException("Slot is not exisit or maybe reserved"); 
            }

            var patient =  await _Patientrepository.GetByIdAsync(patientId) ;
            if (patient is null)
            {
                throw new CreateAppointmentException("Patient Id is not exisit");
            }

            var appointment = new Appointment(slotRefId,patientId,patient.PatientName,slot.Time);
            await _AppointmentRepository.AddAsync(appointment);

            // Mark SlotRef as reserved
            await _SlotRefrepository.MarkeSlotAsReserved(slotRefId,true);
            //Publish ReserveSlot => this Should be in the Slot Ref Entity but i'm not sure !
            var @event = new ReserveSlotEvent(slotRefId,true);
            await _eventBus.Publish(@event);

            // I prefer to make the responsibility of Publish Slot Created Event here instead of repository because in case i will change i will change in both
            //Also, to keep the repo in the state of separation of concerns, we can create a class with these responsibilities later on in the infrastructure.
            appointment.SendAppointmentConfirmation(patient.Id, patient.PatientName, slot.DoctorId, slot.DoctorName, appointment.ReservedAt);
            foreach (var item in appointment.OccurredEvents())
            {
                await _eventBus.Publish((AppointmentConfirmationDetailsEvent)item);
            }
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
        public async Task<Guid> CreatePatientAsync(string name)
        {
            var patient = new Patient(name);
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
