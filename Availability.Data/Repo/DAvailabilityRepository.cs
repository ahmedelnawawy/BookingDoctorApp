using Availability.Data.Contract;
using Availability.Domain;

namespace Availability.Data.Repo
{
    public class DAvailabilityRepository : IDAvailabilityRepository
    {
        private static readonly List<DAvailability> _DAvailability = new();

        public Task AddAsync(DAvailability dAvailability)
        {
            _DAvailability.Add(dAvailability);
            return Task.CompletedTask;
        }

        public Task<DAvailability?> GetByIdAsync(Guid id)
        {
            var dAvailability = _DAvailability.Find(o => o.Id == id);
            return Task.FromResult(dAvailability);
        }
    }
}
