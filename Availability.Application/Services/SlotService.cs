using Availability.Application.Contract;
using Availability.Application.Dtos;
using Availability.Data.Contract;
using Availability.Domain;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.DomainEvents;

namespace Availability.Application.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _repository;
        private readonly IEventBus _eventBus;

        public SlotService(ISlotRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }
        
        public async Task<Guid> CreateSlotAsync(SlotDto CreateRequest)
        {
            var item = new Slot(CreateRequest.Time, CreateRequest.DoctorId, CreateRequest.DoctorName, CreateRequest.IsReserved, CreateRequest.Cost);
            await _repository.AddAsync(item);

            //Publish SlotCreatedEvent
            var @event = new SlotCreatedEvent(item.Id,item.Time,item.DoctorId,item.DoctorName,item.IsReserved);
            await _eventBus.Publish(@event);

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
