using AppointmentBooking.UesCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppintmentBooking.APIs.Controllers
{
    [ApiController]
    [Route("api/Appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _AppointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _AppointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(Guid dAvailabilityRefId, Guid patientId, string patientName, DateTime reservedAt)
        {
            var appointmentId = await _AppointmentService.CreateAppointmentAsync(dAvailabilityRefId,patientId,patientName,reservedAt);
            return Ok(new { AppointmentId = appointmentId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            var appointment = await _AppointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                appointment.Id,
                appointment.PatientId,
                appointment.PatientName,
                appointment.SlotRefId,
                appointment.ReservedAt
            });
        }
    }
}
