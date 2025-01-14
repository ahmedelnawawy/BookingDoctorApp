namespace AppointmentBooking.Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid DAvailabilityRefId { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public DateTime ReservedAt { get; private set; }

        public Appointment(Guid dAvailabilityRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            Id = Guid.NewGuid();
            DAvailabilityRefId = dAvailabilityRefId;
            PatientId = patientId;
            PatientName = patientName;
            ReservedAt = reservedAt;
        }

    }
}
