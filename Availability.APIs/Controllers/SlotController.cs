using Availability.Application.Contract;
using Availability.Application.Dtos;
using Availability.Application.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Availability.APIs.Controllers
{
    [ApiController]
    [Route("api/Slots")]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _SlotService;

        public SlotController(ISlotService slotService)
        {
            _SlotService = slotService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlot(SlotDto Request)
        {
            var slotId = await _SlotService.CreateSlotAsync(Request);
            return Ok(new { SlotId = slotId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSlot(Guid id)
        {
            try
            {
                var slot = await _SlotService.GetSlotAsync(id);
                
                return Ok(new
                {
                    SlotId = slot.Id,
                    time = slot.Time,
                    DctorName = slot.DoctorName,
                    DctorId = slot.DoctorId,
                    slot.IsReserved,
                    cost = slot.Cost
                });
            }
            catch (SlotNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSlot()
        {
            var slots = await _SlotService.GetAllSlotsAsync();
            if (slots.Count == 0 )
            {
                return NotFound();
            }

            return Ok(slots);
        }
    }
}
