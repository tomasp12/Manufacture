namespace EntryControl.Models
{
    public class GateAccess
    {
        public int Id { get; set; }
        public int GateId { get; set; }
        public AuthorizationType AuthorizationType { get; set; }
        public EventType EventType { get; set; }
    }
}
