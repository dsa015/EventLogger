using Logger.Command;
using Logger.Models;
using Logger.Services;
using Logger.ViewModel;
using Microsoft.AspNetCore.Mvc;
 
namespace Logger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private IEventService eventService;

        public EventLogController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpPost("event")]
        public ActionResult<EventViewModel> createEvent([FromBody] EventCommand data)
        {
            var sbankenEvent = eventService.CreateEvent(data);
            if (sbankenEvent is null)
                return NotFound();

            return Ok(Map(sbankenEvent));
        }

        [HttpGet("event")]
        public ActionResult<List<EventViewModel>> getEvents()
        {
            var events = eventService.GetEvents();
            var viewModels = events.Select(Map);

            return Ok(viewModels);
        }

        [HttpGet("event/{id}")]
        public ActionResult<EventViewModel> getEvent([FromRoute] string id)
        {
            var @event = eventService.GetEvent(id);
            if (@event is null)
                return NotFound();

            return Ok(Map(@event));
        }

        [HttpDelete("event/{id}")]
        public ActionResult<EventViewModel> deleteEvent([FromRoute] string id)
        {
            eventService.DeleteEvent(id);
            return Ok();
        }

        [HttpPatch("event/{id}")]
        public ActionResult<EventViewModel> updateEvent([FromRoute] string id, [FromBody] EventCommand data)
        {
            var @event = eventService.UpdateEvent(id, data);
            if (@event is null)
                return NotFound();

            return Ok(Map(@event));
        }

        private static EventViewModel Map(SbankenEvent sbankenEvent) =>
            new()
            {
                EventCode = sbankenEvent.EventCode,
                EventDescription = sbankenEvent.EventDescription,
                Id = sbankenEvent.Id,
                PerformedByUser = sbankenEvent.PerformedByUser,
                ResourceOwnerId = sbankenEvent.ResourceOwnerId,
                TraceId = sbankenEvent.TraceId
            };
    }
}
