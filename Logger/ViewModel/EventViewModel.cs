namespace Logger.ViewModel
{
    public class EventViewModel
    {
        public int ResourceOwnerId { get; set; }
        public int PerformedByUser { get; set; }
        public DateTime EventTime { get; set; }
        public string EventCode { get; set; }
        public string EventDescription { get; set; }
        public string TraceId { get; set; }
        public string Id { get; set; }

    }
}
