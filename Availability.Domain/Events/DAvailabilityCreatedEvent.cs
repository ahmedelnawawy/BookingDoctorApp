﻿
using SharedKernel.EventBus.Domain;

namespace Availability.Domain.Events
{
    public class DAvailabilityCreatedEvent : IDomainEvent
    {
        public Guid Id { get; private set; }
        public int DoctorId { get; private set; }
        public DateTime OccurredOn { get; }

        public DAvailabilityCreatedEvent (Guid id, int doctorId)
        {
            Id = id;
            DoctorId = doctorId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
