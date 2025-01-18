
using SharedKernel.Exceptions;

namespace Availability.Application.Exception
{
    public class SlotNotFoundException : AppException
    {
        public SlotNotFoundException(Guid SlotId)
        : base($"Slot with ID {SlotId} was not found.", 404)
        {
        }
    }
}
