

using Core.InPorts;
using Microsoft.AspNetCore.Mvc;

namespace Shell.Controllers
{
    [ApiController]
    [Route("api/AppointmentManagements")]
    public class AppointmentManagementController : ControllerBase
    {
        private readonly IManagementService _service;

        public AppointmentManagementController(IManagementService service)
        {
            _service = service;
        }

        [HttpPost("{id:guid}")]
        public async Task<IActionResult> MarkDoctorAppointmentAsComplete(Guid id)
        {
            try
            {
                var dAppointment = await _service.MarkAsComplete(id);
                
                return Ok(dAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var dAppointment = await _service.GetDAppointmentById(id);

                return Ok(dAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDoctorAppointment()
        {
            var slots = await _service.GetAllDAppointment();
            if (slots.Count == 0 )
            {
                return NotFound();
            }

            return Ok(slots);
        }
    }
}
