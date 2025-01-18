
using SharedKernel.EventBus.Contracts;

namespace SharedKernel.Classes
{
    public class AggregateRoot
    {

        private List<IDomainEvent> _OccurredEvents = new();
        public void AddEvent (IDomainEvent e)
        {
            _OccurredEvents.Add(e);
        }
        public IReadOnlyCollection<IDomainEvent> OccurredEvents()
        {
            var events = _OccurredEvents.AsReadOnly();
            _OccurredEvents = new();
            return events;
        }
    }
}
