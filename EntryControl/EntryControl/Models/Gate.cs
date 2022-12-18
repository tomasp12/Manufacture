namespace EntryControl.Models
{
    public class Gate
    {
        public int Id { get; set; }        
        public int GateId { get; set; }
        public GateName Name { get; set; }
        public string? Description { get; set; }       

    }
}
