using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.UesCases.Services;
using SharedKernel.EventBus.Domain;
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

        public Task HandleAsync(SlotCreatedEvent @event)
        {
            _service.CreateSlotRefAsync(new SlotRef(@event.Id,@event.Time,@event.DoctorId,@event.DoctorName,@event.IsReserved));
            // Process the event
            Console.WriteLine($"New SlotRef created: {"SlotId"+@event.Id +"-"+ @event.DoctorId + "-" + @event.DoctorName + "-" + @event.OccurredOn}");

            return Task.CompletedTask;
        }
    }
}
