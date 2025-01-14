using Availability.Application.Contract;
using Availability.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Availability.APIs.Controllers
{
    [ApiController]
    [Route("api/DAvailabilities")]
    public class DAvailablityController : ControllerBase
    {
        private readonly IDAvailabilityService _DAvailabilityService;

        public DAvailablityController(IDAvailabilityService dAvailabilityService)
        {
            _DAvailabilityService = dAvailabilityService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDAvailability(DAvailabilityDto Request)
        {
            var dAvailabilityId = await _DAvailabilityService.CreateDAvailabilityAsync(Request);
            return Ok(new { DAvailabilityId = dAvailabilityId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDAvailability(Guid id)
        {
            var dAvailability = await _DAvailabilityService.GetDAvailabilityAsync(id);
            if (dAvailability == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                DAvailabilityId = dAvailability.Id,
                time = dAvailability.Time,
                DctorName = dAvailability.DoctorName,
                DctorId = dAvailability.DoctorId,
                dAvailability.IsReserved,
                cost = dAvailability.Cost
            });
        }
    }
}
