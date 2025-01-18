using AppointmentBooking.Core.Entities;
using AppointmentBooking.Core.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infrastructure.Repo
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppointmentBookingDbContext _context;
        public PatientRepository(AppointmentBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return patient;
        }

        public async Task<Guid> AddAsync(Patient patient)
        {
            var item = await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            var Patients = await _context.Patients.ToListAsync();
            return Patients;
        }
    }
}
