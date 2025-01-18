using Core.InPorts;
using Shared.DTOs;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.DomainEvents;

namespace Core.EventHandlers
{
    public class CreateDAppointmentEventHandler : IDomainEventHandler<CreateDAppointmentEvent>
    {
        private readonly IManagementService _service;

        public CreateDAppointmentEventHandler(IManagementService service)
        {
            _service = service;
        }

        public async Task HandleAsync(CreateDAppointmentEvent @event)
        {
            var createdObj = new CreateDAppointmentDTO 
            {
                PatientId = @event.PatientId,
                PatientName = @event.PatientName,
                ReservedAt = @event.ReservedAt,
                SlotRefId = @event.SlotRefId,
            };
            // Process the event
            await _service.CreateNewDAppointment(createdObj);
            Console.WriteLine($"Mark Doctor Appointment Created: {"PatientId : " + @event.PatientId +"--- Reserved Time: " + @event.ReservedAt}");
        }
    }
}
