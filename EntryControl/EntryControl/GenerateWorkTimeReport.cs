using EntryControl.Data;
using EntryControl.Models;


namespace EntryControl
{
    public class GenerateWorkTimeReport
    {
        private DateTime _timeFrom = DateTime.MinValue;
        private DateTime _timeTo = DateTime.MinValue;
        public GenerateWorkTimeReport() { }

        public GenerateWorkTimeReport(DateTime from, DateTime to)
        {
            _timeFrom = from;
            _timeTo = to;
        }
        public void Generate()
        {
            using var context = new DataContext();
            foreach (var row in context.ReportWorkHours)
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
            

            for (var day = _timeFrom.Date; day.Date <= _timeTo.Date; day = day.AddDays(1))
            {
                foreach (var worker in context.Workers)
                {
                    List<Event> eventsList = context.Events
                        .Where(c => (c.Time.Date == day.Date)
                                    && (c.WorkerId == worker.Id)
                                    && (c.EventType == EventType.Allowed)
                        )
                        .ToList();
                    if (eventsList.Count > 0)
                    {
                        DateTime from = DateTime.MinValue;
                        DateTime to = DateTime.MinValue;
                        TimeSpan total = TimeSpan.Zero;
                        foreach (var evn in eventsList)
                        {
                            if (evn.Action == ActionType.In) 
                            {
                                from = evn.Time;
                            }
                            if (evn.Action == ActionType.Out)
                            {
                                to = evn.Time;
                            }
                            if (from != DateTime.MinValue && to != DateTime.MinValue)
                            {
                                TimeSpan timeSpent = to - from;
                                from = DateTime.MinValue;
                                to = DateTime.MinValue;
                                total += timeSpent;
                            }
                        }

                        WorkTimeReportLine report = new();
                        if (context.ReportWorkHours.Any(c => (c.Year == day.Year)
                                                             && (c.WorkerId == worker.Id)
                                                             && (c.Month == day.Month)))
                        {
                            report = context.ReportWorkHours
                                .Where(c => (c.Year == day.Year)
                                            && (c.WorkerId == worker.Id)
                                            && (c.Month == day.Month))
                                .First();
                            report.WorkSeconds += (int)total.TotalSeconds;
                        }
                        else 
                        {   
                            report.WorkSeconds = (int)total.TotalSeconds;   
                            report.WorkerId = worker.Id;
                            report.Year = day.Year;
                            report.Month = day.Month;
                            context.ReportWorkHours.Add(report);
                        }   
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
