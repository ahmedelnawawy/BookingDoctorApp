using SharedKernel.EventBus.Contracts;

namespace SharedKernel.EventBus.DomainEvents
{
    public class AppointmentConfirmationDetailsEvent : IDomainEvent
    {
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public int DctorId { get; private set; }
        public string DctorName { get; private set; }
        public DateTime AppoinmentTime { get; private set; }
        public DateTime OccurredOn { get; }
        public AppointmentConfirmationDetailsEvent(Guid patientId, string patientName, int dctorId, string dctorName, DateTime appoinmentTime)
        {
            PatientId = patientId;
            PatientName = patientName;
            DctorId = dctorId;
            DctorName = dctorName;
            AppoinmentTime = appoinmentTime;
        }
    }
}
