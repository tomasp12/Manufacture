namespace EntryControl.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }        
        public ActionType Action { get; set; }
        public EventType EventType { get; set; }
        public int WorkerId { get; set; }
        public int GateId { get; set; }
    }
}
