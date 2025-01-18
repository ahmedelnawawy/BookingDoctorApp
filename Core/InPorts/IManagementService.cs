using Core.Models;
using Shared.DTOs;

namespace Core.InPorts
{
    public interface IManagementService
    {
        Task<Guid> CreateNewDAppointment(CreateDAppointmentDTO Dto);
        Task<List<DAppointment>> GetAllDAppointment();
        Task<DAppointment> GetDAppointmentById(Guid Id);
        Task<DAppointment> MarkAsComplete(Guid Id);
    }
}
