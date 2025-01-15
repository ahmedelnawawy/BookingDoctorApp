using Availability.Data.Contract;
using SharedKernel.EventBus.Domain;
using SharedKernel.EventBus.DomainEvents;

namespace AppointmentBooking.UesCases.EventHandlers
{
    public class ReserveSlotEventHandler : IDomainEventHandler<ReserveSlotEvent>
    {
        private readonly ISlotRepository _slotRepository;
        
        public ReserveSlotEventHandler(ISlotRepository repository)
        {
            _slotRepository = repository;
        }

        public Task HandleAsync(ReserveSlotEvent @event)
        {
            _slotRepository.MarkeSlotAsReserved(@event.Id,@event.IsReserved);
            // Process the event
            Console.WriteLine($"Mark slot as Reserved: {"SlotId"+@event.Id +"-"+ @event.IsReserved + "-" + @event.OccurredOn}");

            return Task.CompletedTask;
        }
    }
}
