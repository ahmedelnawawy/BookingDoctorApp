using AppointmentBooking.Core.Entities;
using AppointmentBooking.UesCases.Services;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.DomainEvents;

namespace AppointmentBooking.UesCases.EventHandlers
{
    public class SlotCreatedEventHandler : IDomainEventHandler<SlotCreatedEvent>
    {
        private readonly IAppointmentService _service;
        
        public SlotCreatedEventHandler(IAppointmentService service)
        {
            _service = service;
        }

        public async Task HandleAsync(SlotCreatedEvent @event)
        {
            // Process the event
            await _service.CreateSlotRefAsync(new SlotRef(@event.Id,@event.Time,@event.DoctorId,@event.DoctorName,@event.IsReserved));
            Console.WriteLine($"New SlotRef created: {"SlotId"+@event.Id +"-"+ @event.DoctorId + "-" + @event.DoctorName + "-" + @event.OccurredOn}");
        }
    }
}
