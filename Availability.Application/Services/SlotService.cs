using Availability.Application.Contract;
using Availability.Application.Dtos;
using Availability.Application.Exception;
using Availability.Data.Contract;
using Availability.Domain;
using Microsoft.Extensions.Logging;
using SharedKernel.EventBus.Contracts;
using SharedKernel.EventBus.DomainEvents;

namespace Availability.Application.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _repository;
        private readonly IEventBus _eventBus;
        private readonly ILogger<SlotService> _logger;

        public SlotService(ISlotRepository repository, IEventBus eventBus, ILogger<SlotService> logger)
        {
            _repository = repository;
            _eventBus = eventBus;
            _logger = logger;
        }
        
        public async Task<Guid> CreateSlotAsync(SlotDto CreateRequest)
        {
            var createdSlot = new Slot(CreateRequest.Time, CreateRequest.DoctorId, CreateRequest.DoctorName, CreateRequest.IsReserved, CreateRequest.Cost);
            await _repository.AddAsync(createdSlot);
            _logger.LogInformation("New Slot Created With Id = {Id}", createdSlot.Id);

            // I prefer to make the responsibility of Publish Slot Created Event here instead of repository because in case i will change i will change in both
            //Also, to keep the repo in the state of separation of concerns, we can create a class with these responsibilities later on in the infrastructure.
            foreach (var item in createdSlot.OccurredEvents())
            {
                await _eventBus.Publish((SlotCreatedEvent)item);
            }
            return createdSlot.Id;
        }

        public async Task<List<Slot>> GetAllSlotsAsync()
        {
            return await _repository.GetAllSlotsAsync();
        }

        public Task<Slot> GetSlotAsync(Guid id)
        {
            var slot = _repository.GetByIdAsync(id);
            if (slot == null)
            {
                throw new SlotNotFoundException(id);
            }
            return _repository.GetByIdAsync(id);
        }
    }
}
