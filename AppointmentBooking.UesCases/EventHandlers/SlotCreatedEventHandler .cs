using SharedKernel.EventBus.Domain;
using SharedKernel.EventBus.DomainEvents;

namespace AppointmentBooking.UesCases.EventHandlers
{
    public class SlotCreatedEventHandler : IDomainEventHandler<SlotCreatedEvent>
    {
        public Task HandleAsync(SlotCreatedEvent @event)
        {
            // Process the event
            Console.WriteLine($"New customer created: {@event.Id +"-"+ @event.DoctorId+ "-" + @event.OccurredOn}");
            return Task.CompletedTask;
        }
    }
}
