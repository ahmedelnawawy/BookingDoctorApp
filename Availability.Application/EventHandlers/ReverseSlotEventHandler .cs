using Availability.Data.Contract;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.DomainEvents;

namespace Availability.Application.EventHandlers
{
    public class ReserveSlotEventHandler : IDomainEventHandler<ReserveSlotEvent>
    {
        private readonly ISlotRepository _slotRepository;
        
        public ReserveSlotEventHandler(ISlotRepository repository)
        {
            _slotRepository = repository;
        }

        public async Task HandleAsync(ReserveSlotEvent @event)
        {
            // Process the event
            await _slotRepository.MarkeSlotAsReserved(@event.Id,@event.IsReserved);
            Console.WriteLine($"Mark slot as Reserved: {"SlotId"+@event.Id +"-"+ @event.IsReserved + "-" + @event.OccurredOn}");
        }
    }
}
