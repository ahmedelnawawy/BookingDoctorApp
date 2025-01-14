namespace AppointmentBooking.Core.Entities
{
    public class DAvailabilityRef
    {
        public Guid Id { get; private set; }
        public int DctorId { get; private set; }
        public DAvailabilityRef(Guid id , int dctorId )
        {
            Id = id;
            DctorId = dctorId;
        }
    }
}
