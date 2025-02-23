﻿namespace AppointmentBooking.Core.Entities
{
    public class SlotRef
    {
        public Guid Id { get; private set; }
        public DateTime Time { get; private set; }
        public int DoctorId { get; private set; }
        public string DoctorName { get; private set; }
        public bool IsReserved { get; private set; }
        public SlotRef(Guid id,DateTime time, int doctorId, string doctorName, bool isReserved)
        {
            Id = id;
            Time = time;
            DoctorId = doctorId;
            DoctorName = doctorName;
            IsReserved = isReserved;
        }
        public void MarkSlotAsReversed(bool isReserved) => IsReserved = isReserved;
    }
}
