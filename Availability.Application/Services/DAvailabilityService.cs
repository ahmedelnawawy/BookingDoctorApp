using Availability.Application.Contract;
using Availability.Application.Dtos;
using Availability.Data.Contract;
using Availability.Domain;
using Availability.Domain.Events;
using SharedKernel.EventBus.Infrastructure;

namespace Availability.Application.Services
{
    public class DAvailabilityService : IDAvailabilityService
    {
        private readonly IDAvailabilityRepository _repository;
        private readonly InMemoryEventBus _eventBus;

        public DAvailabilityService(IDAvailabilityRepository repository, InMemoryEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }
        
        public async Task<Guid> CreateDAvailabilityAsync(DAvailabilityDto CreateRequest)
        {
            var item = new DAvailability(CreateRequest.Time, CreateRequest.DoctorId, CreateRequest.DoctorName, CreateRequest.IsReserved, CreateRequest.Cost);
            await _repository.AddAsync(item);

            //Publish DAvailabilityCreatedEvent
            var @event = new DAvailabilityCreatedEvent(item.Id, item.DoctorId);
            await _eventBus.PublishAsync(@event);

            return item.Id;
        }

        public Task<DAvailability?> GetDAvailabilityAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
