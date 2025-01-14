using Availability.Domain;

namespace Availability.Data.Contract
{
    public interface IDAvailabilityRepository
    {
        Task AddAsync(DAvailability order);
        Task<DAvailability?> GetByIdAsync(Guid id);
    }
}
