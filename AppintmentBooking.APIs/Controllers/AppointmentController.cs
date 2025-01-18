using AppointmentBooking.Core.Entities;
using AppointmentBooking.UesCases.Exceptions;
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
        public async Task<IActionResult> CreateAppointment(Guid SlotId, Guid patientId)
        {
            try
            {
                var appointmentId = await _AppointmentService.CreateAppointmentAsync(SlotId, patientId);
                return Ok(new { AppointmentId = appointmentId });
            }
            catch(CreateAppointmentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
            
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSlot()
        {
            var Appointments = await _AppointmentService.GetAllSlotsAsync();
            if (Appointments.Count == 0)
            {
                return NotFound();
            }

            return Ok(Appointments);
        }

        // Patient
        [HttpPost("Patient")]
        public async Task<IActionResult> CreatePatient(string PatientName)
        {
            var PatientId = await _AppointmentService.CreatePatientAsync(PatientName);
            return Ok(new { PatientId });
        }

        [HttpGet("Patient/{id:guid}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var Patient = await _AppointmentService.GetPatientByIdAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Patient.Id,
                Patient.PatientName
            });
        }

        [HttpGet("Patient/GetAll")]
        public async Task<IActionResult> GetAllPatient()
        {
            var patients = await _AppointmentService.GetAllPatientsAsync();
            if (patients.Count == 0)
            {
                return NotFound();
            }

            return Ok(patients);
        }
    }
}
