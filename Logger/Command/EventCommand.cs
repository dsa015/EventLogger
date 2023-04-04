namespace Logger.Command
{
    public class EventCommand
    {
        public int ResourceOwnerId { get; set; }
        public int PerformedByUser { get; set; }
        public string EventCode { get; set; }
        public string EventDescription { get; set; }
    }
}
