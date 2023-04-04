using Logger.Command;
using Logger.ViewModel;
using Microsoft.AspNetCore.Mvc;
 
namespace Logger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        List<EventViewModel> events = new List<EventViewModel>();

        public EventLogController() {
            events.Add(new EventViewModel {EventCode="success",EventDescription="bla bla bla",ResourceOwnerId=1});
        }


        [HttpPost("event")]
        public ActionResult<EventViewModel> createEvent([FromBody] EventCommand data)
        {
            if (data == null) return BadRequest("Missing body");
            var @event = EventCommandToViewModel(data);
            events.Add(@event);

            return Ok(@event);
        }

        [HttpGet("event")]
        public ActionResult<List<EventViewModel>> getEvenst()
        {
            return Ok(events);
        }

        [HttpGet("event/{id}")]
        public ActionResult<EventViewModel> getEvent([FromRoute] string id)
        {
            if (id == null) return Ok(events);
            EventViewModel @event = events.FirstOrDefault(x => x.Id == id);
            if (@event == null) return NotFound("Event not found");

            return Ok(@event); 
        }

        [HttpDelete("event/{id}")]
        public ActionResult<EventViewModel> deleteEvent([FromRoute] string id)
        {
            if (id == null) return BadRequest("Missing event id in route");
            EventViewModel @event = events.FirstOrDefault(x => x.Id == id);
            if (@event == null) return NotFound("Event not found");
            events.Remove(@event); 

            return Ok();
        }

        [HttpPatch("event/{id}")]
        public ActionResult<EventViewModel> updateEvent([FromRoute] string id, [FromBody] EventCommand data)
        {
            if (id == null) return BadRequest("Missing event id in route");
            EventViewModel @event = events.FirstOrDefault(x => x.Id == id);
            if (@event == null) return NotFound("Event not found");
            events.Remove(@event);

            @event.EventDescription = data.EventDescription;
            @event.PerformedByUser = data.PerformedByUser;
            @event.ResourceOwnerId = data.ResourceOwnerId;
            @event.EventCode = data.EventCode;

            events.Add(@event);

            return Ok(@event);
        }

        private EventViewModel EventCommandToViewModel(EventCommand command) =>
            new()
            {
                EventCode = command.EventCode,
                EventDescription = command.EventDescription,
                ResourceOwnerId = command.ResourceOwnerId,
                PerformedByUser = command.PerformedByUser
            };
    }
}
