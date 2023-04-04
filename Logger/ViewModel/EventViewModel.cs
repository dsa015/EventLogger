namespace Logger.ViewModel
{
    public class EventViewModel
    {
        public int ResourceOwnerId { get; set; }
        public int PerformedByUser { get; set; }
        public DateTime EventTime { get; } = new DateTime();
        public string EventCode { get; set; }
        public string EventDescription { get; set; }
        public string TraceId { get; } = Guid.NewGuid().ToString();
        public string Id { get; } = Guid.NewGuid().ToString();

    }
}
