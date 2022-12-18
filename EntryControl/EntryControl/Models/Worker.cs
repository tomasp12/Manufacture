namespace EntryControl.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }        
        public AuthorizationType AuthorizationLevel { get; set; }
    }
}
