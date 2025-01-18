using SharedKernel.EventBus.DomainEvents;
using SharedKernel.EventBus.Contracts;

namespace AppointmentConfirmation.EventHandlers
{
    public class AppointmentConfirmationEventHandler : IDomainEventHandler<AppointmentConfirmationDetailsEvent>
    {
        public AppointmentConfirmationEventHandler()
        {
        }

        public Task HandleAsync(AppointmentConfirmationDetailsEvent @event)
        {
            // Process the event
            Console.WriteLine($"Appointment Confirmation Notification Send to : " +
                $"{"PatientName is " + @event.PatientName + " ---- Dctor name is " + @event.DctorName + "------ AppointmentTime : " + @event.AppoinmentTime}");

            return Task.CompletedTask;
        }
    }
}
