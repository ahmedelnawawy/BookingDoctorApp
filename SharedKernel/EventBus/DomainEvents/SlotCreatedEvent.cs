using SharedKernel.EventBus.Contracts;

namespace SharedKernel.EventBus.DomainEvents
{
    public class SlotCreatedEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public DateTime Time { get; private set; }
        public int DoctorId { get; private set; }
        public string DoctorName { get; private set; }
        public bool IsReserved { get; private set; }
        public DateTime OccurredOn { get; }

        public SlotCreatedEvent(Guid id , DateTime time, int doctorId, string doctorName, bool isReserved)
        {
            Id = id;
            Time = time;
            DoctorId = doctorId;
            DoctorName = doctorName;
            IsReserved = isReserved;
            OccurredOn = DateTime.Now;
        }
    }
}
