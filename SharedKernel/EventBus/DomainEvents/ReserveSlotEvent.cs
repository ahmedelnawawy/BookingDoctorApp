using SharedKernel.EventBus.Contracts;

namespace SharedKernel.EventBus.DomainEvents
{
    public class ReserveSlotEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public bool IsReserved { get; private set; }
        public DateTime OccurredOn { get; }
        public ReserveSlotEvent(Guid id, bool isReserved)
        {
            Id = id;
            IsReserved = isReserved;
            OccurredOn = DateTime.Now;
        }
    }
}
