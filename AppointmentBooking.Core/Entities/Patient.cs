
namespace AppointmentBooking.Core.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string PatientName { get; private set; }

        public Patient(string patientName) 
        { 
            Id = Guid.NewGuid();
            PatientName = patientName;
        }
    }
}
