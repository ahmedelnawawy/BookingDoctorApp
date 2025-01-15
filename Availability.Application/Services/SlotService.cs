using Availability.Application.Contract;
using Availability.Application.Dtos;
using Availability.Data.Contract;
using Availability.Domain;
using SharedKernel.EventBus.DomainEvents;
using SharedKernel.EventBus.Infrastructure;

namespace Availability.Application.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _repository;
        private readonly InMemoryEventBus _eventBus;

        public SlotService(ISlotRepository repository, InMemoryEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }
        
        public async Task<Guid> CreateSlotAsync(SlotDto CreateRequest)
        {
            var item = new Slot(CreateRequest.Time, CreateRequest.DoctorId, CreateRequest.DoctorName, CreateRequest.IsReserved, CreateRequest.Cost);
            await _repository.AddAsync(item);

            //Publish SlotCreatedEvent
            var @event = new SlotCreatedEvent(item.Id, item.DoctorId);
            await _eventBus.PublishAsync(@event);

            return item.Id;
        }

        public async Task<List<Slot>> GetAllSlotsAsync()
        {
            return await _repository.GetAllSlotsAsync();
        }

        public Task<Slot?> GetSlotAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
