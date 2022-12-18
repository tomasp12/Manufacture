namespace EntryControl.Models
{
    public class EntryEventReportLine
    {
        public int Id { get; set; }
        public DateTime EvenTime{ get; set; }
        public string? Action { get; set; }
        public string? FullName { get; set; }
        public string? AuthorizationLevel { get; set; }
        public string? GateName { get; set; }
        public string? EventType { get; set; }
    }
}
