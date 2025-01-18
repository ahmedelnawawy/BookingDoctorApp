using Core.InPorts;
using Core.Models;
using Core.OutPorts;
using Shared.DTOs;

namespace Core.Services
{
    public class ManagementService : IManagementService
    {
        private readonly IDAppointmentRepository _repository;
        public ManagementService(IDAppointmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> CreateNewDAppointment(CreateDAppointmentDTO Dto)
        {
           return await _repository.AddAsync(Dto);
        }

        public async Task<List<DAppointment>> GetAllDAppointment()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DAppointment> GetDAppointmentById(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<DAppointment> MarkAsComplete(Guid Id)
        {
            var item = await _repository.GetByIdAsync(Id);
            item.MarkAppoinmentAsComplete(true);
            return await _repository.UpdateAsync(item);
        }
    }
}
