namespace Core.Models
{
    public class DAppointment
    {
        public Guid Id { get; private set; }
        public Guid SlotRefId { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public DateTime ReservedAt { get; private set; }
        public bool IsCompleted { get; private set; }

        public DAppointment(Guid slotRefId, Guid patientId, string patientName, DateTime reservedAt, bool isCompleted = false)
        {
            Id = Guid.NewGuid();
            SlotRefId = slotRefId;
            PatientId = patientId;
            PatientName = patientName;
            ReservedAt = reservedAt;
            IsCompleted = isCompleted;
        }

        public void MarkAppoinmentAsComplete(bool isCompleted)
        {
            IsCompleted = isCompleted;
        }
    }
}
