using EntryControl.Data;
using EntryControl.Models;

namespace EntryControl
{
    public class GenerateEventsReport
    {
        private DateTime _timeFrom = DateTime.MinValue;
        private DateTime _timeTo = DateTime.MinValue;

        public GenerateEventsReport()
        {
        }

        public GenerateEventsReport(DateTime from, DateTime to)
        {
            _timeFrom = from;
            _timeTo = to;
        }

        public void Generate()
        {
            using var context = new DataContext();
            foreach (var row in context.ReportEvents)
            {
                context.Remove(row);
            }
            context.SaveChanges();
            if (_timeFrom == DateTime.MinValue)
            {
                _timeFrom = context.Events
                    .Select(c => c.Time)
                    .First();
            }

            if (_timeTo == DateTime.MinValue)
            {
                _timeTo = context.Events
                    .Select(c => c.Time)
                    .OrderBy(x => x.Date)
                    .Last();
            }

            foreach (var worker in context.Workers.OrderBy(c=>c.Name))
            {
                foreach (Event eventRow in context.Events.Where(c => (c.Time >= _timeFrom) 
                                                                     && (c.Time <= _timeTo) 
                                                                     && (c.WorkerId == worker.Id)))
                {
                    context.ReportEvents.Add(new ReportEvent
                    {
                        EvenTime = eventRow.Time,
                        Action = eventRow.Action.ToString(),
                        FullName = $"{worker.Name} {worker.Surname}",
                        AuthorizationLevel = worker.AuthorizationLevel.ToString(),
                        GateName = context.Gates.Where(x => x.Id == eventRow.GateId).FirstOrDefault()?.Name.ToString(),
                        EventType = ((EventType)eventRow.EventType).ToString()

                    });
                }
            }

            context.SaveChanges();

        }

        
    }
}
