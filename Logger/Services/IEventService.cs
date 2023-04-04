using Logger.Command;
using Logger.Models;

namespace Logger.Services
{
    public interface IEventService
    {
        SbankenEvent CreateEvent(EventCommand eventCommand);
        void DeleteEvent(string eventId);
        SbankenEvent GetEvent(string eventId);
        SbankenEvent[] GetEvents();
        SbankenEvent UpdateEvent(string eventId, EventCommand eventCommand);
    }
}