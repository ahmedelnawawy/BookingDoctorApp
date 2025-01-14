using Availability.Application.Contract;
using Availability.Application.Dtos;
using Availability.Data.Contract;
using Availability.Domain;

namespace Availability.Application.Services
{
    public class DAvailabilityService : IDAvailabilityService
    {
        private readonly IDAvailabilityRepository _repository;
      
        public DAvailabilityService(IDAvailabilityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> CreateDAvailabilityAsync(DAvailabilityDto CreateRequest)
        {
            var item = new DAvailability(CreateRequest.Time, CreateRequest.DoctorId, CreateRequest.DoctorName, CreateRequest.IsReserved, CreateRequest.Cost);
            await _repository.AddAsync(item);
            return item.Id;
        }

        public Task<DAvailability?> GetOrderAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }
    }
}
