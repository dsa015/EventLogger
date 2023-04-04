using System;
namespace Logger.Models
{
	public class SbankenEvent
	{
        private List<string> availableEventCodes = new() { "USER_LOGGED_IN", "USER_LOGGED_OUT" };

        public SbankenEvent(int resourceOwnerId, int performedByUser, string eventCode, string eventDescription)
        {
            ResourceOwnerId = resourceOwnerId;
            PerformedByUser = performedByUser;
            EventTime = DateTime.UtcNow;
            EventCode = eventCode ?? throw new ArgumentNullException(nameof(eventCode));
            EventDescription = eventDescription ?? throw new ArgumentNullException(nameof(eventDescription));
            TraceId = Guid.NewGuid().ToString();
            Id = Guid.NewGuid().ToString();

            if (!availableEventCodes.Contains(eventCode))
            {
                throw new ArgumentException("Invalid event code", nameof(eventCode));
            }
        }

        public int ResourceOwnerId { get; private set; }
        public int PerformedByUser { get; private set; }
        public DateTime EventTime { get; set; }
        public string EventCode { get; private set; }
        public string EventDescription { get; private set; }
        public string TraceId { get; }
        public string Id { get; }

        public void Update(int resourceOwner, int performedByUser, string eventCode, string eventDescription)
        {
            if (string.IsNullOrEmpty(eventCode))
            {
                throw new ArgumentException($"'{nameof(eventCode)}' cannot be null or empty.", nameof(eventCode));
            }

            if (string.IsNullOrEmpty(eventDescription))
            {
                throw new ArgumentException($"'{nameof(eventDescription)}' cannot be null or empty.", nameof(eventDescription));
            }

            ResourceOwnerId = resourceOwner;
            PerformedByUser = performedByUser;
            EventCode = eventCode;
            EventDescription = eventDescription;
        }
    }
}

