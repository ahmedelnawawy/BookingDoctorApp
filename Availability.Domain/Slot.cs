namespace Availability.Domain
{
    public class Slot
    {
        public Guid Id { get; private set; }
        public DateTime Time { get; private set; }
        public int DoctorId { get; private set; }
        public string DoctorName { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Cost { get; private set; }

        public Slot(DateTime time, int doctorId , string doctorName ,bool isReserved , decimal cost)
        {
            Id = Guid.NewGuid();
            Time = time;
            DoctorId = doctorId;
            DoctorName = doctorName;
            IsReserved = isReserved;
            Cost = cost;
        }

        public void MarkSlotAsReversed(bool isReserved) => IsReserved = isReserved;
    }
}
