using SharedKernel.EventBus.Domain;

namespace SharedKernel.EventBus.DomainEvents
{
    public class SlotCreatedEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public int DoctorId { get; private set; }
        public DateTime OccurredOn { get; }

        public SlotCreatedEvent(Guid id, int doctorId)
        {
            Id = id;
            DoctorId = doctorId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
