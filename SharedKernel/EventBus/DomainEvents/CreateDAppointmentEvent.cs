using SharedKernel.EventBus.Contracts;

namespace SharedKernel.EventBus.DomainEvents
{
    public class CreateDAppointmentEvent : IDomainEvent
    {
        public Guid SlotRefId { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public DateTime ReservedAt { get; private set; }
        public DateTime OccurredOn { get; }

        public CreateDAppointmentEvent(Guid slotRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            SlotRefId = slotRefId;
            PatientId = patientId;
            PatientName = patientName;
            ReservedAt = reservedAt;
        }
    }
}
