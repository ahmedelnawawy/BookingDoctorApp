using SharedKernel.Exceptions;

namespace AppointmentBooking.UesCases.Exceptions
{
    public class CreateAppointmentException : AppException
    {
        public CreateAppointmentException(string message)
        : base($"Appointment creation failed: {message}", 400)
        {
        }
    }
}
