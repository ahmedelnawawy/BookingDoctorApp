using Core.Models;
using Shared.DTOs;

namespace Core.OutPorts
{
    public interface IDAppointmentRepository
    {
        Task<Guid> AddAsync(CreateDAppointmentDTO dAppoinmentDto);
        Task<List<DAppointment>> GetAllAsync();
        Task<DAppointment> GetByIdAsync(Guid id);
        Task<DAppointment> UpdateAsync(DAppointment updatedObj);
    }
}
