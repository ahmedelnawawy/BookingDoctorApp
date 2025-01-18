using SharedKernel.Classes;
using SharedKernel.EventBus.DomainEvents;

namespace AppointmentBooking.Core.Entities
{
    public class Appointment : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid SlotRefId { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public DateTime ReservedAt { get; private set; }

        public Patient? Patient { get; set; }
        public SlotRef? SlotRef { get; set; }

        public Appointment(Guid slotRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            Id = Guid.NewGuid();
            SlotRefId = slotRefId;
            PatientId = patientId;
            PatientName = patientName;
            ReservedAt = reservedAt;
        }

        public void SendAppointmentConfirmation(Guid patientId, string patientName,int dctorId,string dctorName ,DateTime reservedAt)
        {
            AddEvent(new AppointmentConfirmationDetailsEvent(PatientId, PatientName, dctorId, dctorName, ReservedAt));
        }

    }
}
