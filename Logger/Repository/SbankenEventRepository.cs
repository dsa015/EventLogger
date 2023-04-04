using System;
using Logger.Models;
using Logger.ViewModel;

namespace Logger.Repository
{
    public class SbankenEventRepository : ISbankenEventRepository
    {
        List<SbankenEvent> events = new List<SbankenEvent>();

        public void Save(SbankenEvent sbankenEvent)
        {
            var existingEvent = events.FirstOrDefault(e => e.Id == sbankenEvent.Id);

            if (existingEvent is null)
                events.Add(sbankenEvent);
            else
            {
                var indexOfExistingEvent = events.IndexOf(existingEvent);
                events[indexOfExistingEvent] = sbankenEvent;
            }
        }

        public SbankenEvent GetById(string eventId)
        {
            return events.FirstOrDefault(e => e.Id == eventId);
        }

        public SbankenEvent[] GetAll()
        {
            return events.ToArray();
        }

        public void Delete(string eventId)
        {
            events.Remove(GetById(eventId));
        }

    }
}

