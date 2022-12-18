namespace EntryControl.Models
{
    public class WorkTimeReportLine
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month{ get; set; }
        public int WorkerId { get; set; }        
        public int WorkSeconds { get; set; }
        
    }
}
