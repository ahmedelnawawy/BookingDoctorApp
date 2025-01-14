using Availability.Application.Contract;
using Availability.Application.Dtos;
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
            var slot = await _SlotService.GetSlotAsync(id);
            if (slot == null)
            {
                return NotFound();
            }

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
    }
}
