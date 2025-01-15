namespace AppointmentBooking.Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid SlotRefId { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public DateTime ReservedAt { get; private set; }

        public Appointment(Guid slotRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            Id = Guid.NewGuid();
            SlotRefId = slotRefId;
            PatientId = patientId;
            PatientName = patientName;
            ReservedAt = reservedAt;
        }

    }
}
