using Core.Models;
using Core.OutPorts;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shell.Data;

namespace Shell.Repositories
{
    public class DAppointmentRepository : IDAppointmentRepository
    {
        private readonly AppointmentManagementDbContext _context;
        
        public DAppointmentRepository(AppointmentManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(CreateDAppointmentDTO dAppointmentDTO)
        {
            var newDAppoinment = new DAppointment(dAppointmentDTO.SlotRefId, dAppointmentDTO.PatientId, dAppointmentDTO.PatientName, dAppointmentDTO.ReservedAt);
            await _context.DAppointments.AddAsync(newDAppoinment);
            await _context.SaveChangesAsync();
            return newDAppoinment.Id;
        }

        public async Task<List<DAppointment>> GetAllAsync()
        {
            var dAppoinments = await _context.DAppointments.ToListAsync();
            return dAppoinments;
        }

        public async Task<DAppointment> GetByIdAsync(Guid id)
        {
            var dAppoinment = await _context.DAppointments.FindAsync(id);
            if (dAppoinment == null)
            {
                throw new Exception("Handled in Infra . Not Found dAppointment");
            }
            return dAppoinment;
        }

        public Task<DAppointment> UpdateAsync(DAppointment updatedObj)
        {
             var res = _context.DAppointments.Update(updatedObj);
            return Task.FromResult(res.Entity);
        }
    }
}
