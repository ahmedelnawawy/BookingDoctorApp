using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;

namespace PatientBooking.Infrastructure.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Dictionary<Guid, Patient> _db = new();

        public Task<Patient?> GetByIdAsync(Guid id)
        {
            _db.TryGetValue(id, out var patient);
            return Task.FromResult(patient);
        }

        public Task AddAsync(Patient patient)
        {
            _db[patient.Id] = patient;
            return Task.CompletedTask;
        }

        public Task<List<Patient>> GetAllAsync()
        {
            return Task.FromResult(_db.Values.ToList());
        }
    }
}
