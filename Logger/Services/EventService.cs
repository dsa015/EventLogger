using System;
using Logger.Command;
using Logger.Models;
using Logger.Repository;

namespace Logger.Services
{
    public class EventService : IEventService
    {
        private ISbankenEventRepository repository;

        public EventService(ISbankenEventRepository repository)
        {
            this.repository = repository;
        }

        public SbankenEvent CreateEvent(EventCommand eventCommand)
        {
            var sbankenEvent = Map(eventCommand);
            repository.Save(sbankenEvent);

            return sbankenEvent;
        }

        public SbankenEvent GetEvent(string eventId)
        {
            return repository.GetById(eventId);
        }

        public SbankenEvent[] GetEvents()
        {
            return repository.GetAll().ToArray();
        }

        public SbankenEvent UpdateEvent(string eventId, EventCommand eventCommand)
        {
            var existingEvent = repository.GetById(eventId);
            if (existingEvent is null)
                throw new InvalidOperationException("Event not found");

            existingEvent.Update(eventCommand.ResourceOwnerId,
                        eventCommand.PerformedByUser,
                        eventCommand.EventCode,
                        eventCommand.EventDescription);

            repository.Save(existingEvent);

            return existingEvent;
        }

        public void DeleteEvent(string eventId)
        {
            repository.Delete(eventId);
        }

        private static SbankenEvent Map(EventCommand command) =>
            new SbankenEvent(command.ResourceOwnerId,
                    command.PerformedByUser,
                    command.EventCode,
                    command.EventDescription);
    }
}

