﻿namespace Availability.Application.Dtos
{
    public class SlotDto
    {
        public DateTime Time { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
