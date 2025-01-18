namespace Shared.DTOs
{
    public class CreateDAppointmentDTO
    {
        public Guid SlotRefId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime ReservedAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
