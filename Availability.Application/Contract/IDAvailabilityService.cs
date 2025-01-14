using Availability.Application.Dtos;
using Availability.Domain;

namespace Availability.Application.Contract
{
    public interface IDAvailabilityService
    {
        Task<Guid> CreateDAvailabilityAsync(DAvailabilityDto CreateRequest);
        Task<DAvailability?> GetDAvailabilityAsync(Guid id);
    }
}
