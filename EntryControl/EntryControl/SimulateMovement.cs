using EntryControl.Data;
using EntryControl.Models;

namespace EntryControl
{
    public class SimulateMovement
    {
        private  DateTime _timeFrom = new(2022, 1, 1);
        private DateTime _timeTo = new(2022, 2, 28);
        private Random _rnd = new();
        public SimulateMovement() 
        {
        }
        public SimulateMovement(DateTime from, DateTime to)
        {
            _timeFrom = from;
            _timeTo = to;
        }
        public void Simulate()
        {
            using var context = new DataContext();
            foreach (var row in context.Events)
            {
                context.Remove(row);
            }
            context.SaveChanges();
            for (var day = _timeFrom.Date; day.Date <= _timeTo.Date; day = day.AddDays(1))
            {
                if (day.DayOfWeek != DayOfWeek.Saturday || day.DayOfWeek != DayOfWeek.Sunday)
                {  
                    for (int i = 0; i < 4; i++)
                    {

                        var random = RandomValueGenerate();
                        var now = new DateTime(day.Year, day.Month, day.Day, random[$"Hour{i}"], random[$"Min{i}"], random[$"Sec{i}"]);
                        var action = random[$"Direction{i}"] == 1 ? ActionType.Out : ActionType.In;

                        foreach (var worker in context
                                     .Workers
                                     .OrderBy(x => Guid.NewGuid())
                                     .ToList()
                                )
                        {
                            var gates = RandomNumbersGenerate(1, 5);
                            now = now.AddMinutes(RandomNumbersGenerate(1, 6));
                            now = now.AddSeconds(RandomNumbersGenerate(1, 60));
                            var eventType = EventType.Allowed;
                            do
                            {
                                eventType = context.GateAccess
                                    .Where(s => (s.GateId == gates) && (s.AuthorizationType == worker.AuthorizationLevel))
                                    .Select(c => c.EventType)
                                    .First();
                                context.Events.Add(new Event()
                                {
                                    WorkerId = worker.Id,
                                    GateId = gates,
                                    Time = now,
                                    Action = action,
                                    EventType = eventType
                                });
                                gates = RandomNumbersGenerate(1, 5);
                                now = now.AddMinutes(RandomNumbersGenerate(1, 6));
                                now = now.AddSeconds(RandomNumbersGenerate(1, 60));
                            } while (eventType != EventType.Allowed);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
        private Dictionary<string, int> RandomValueGenerate()
        {
            var randomDictionary = new Dictionary<string, int>
            {
                { "Hour0", RandomNumbersGenerate(7, 9) },
                { "Min0", RandomNumbersGenerate(0, 60) },
                { "Sec0", RandomNumbersGenerate(0, 60) },
                { "Direction0", 0 },
                { "Hour1", RandomNumbersGenerate(12, 14) },
                { "Min1", RandomNumbersGenerate(0, 60) },
                { "Sec1", RandomNumbersGenerate(0, 60) },
                { "Direction1", 1 },
                { "Hour2", RandomNumbersGenerate(13, 15) },
                { "Min2", RandomNumbersGenerate(0, 60) },
                { "Sec2", RandomNumbersGenerate(0, 60) },
                { "Direction2", 0 },
                { "Hour3", RandomNumbersGenerate(16, 19) },
                { "Min3", RandomNumbersGenerate(0, 60) },
                { "Sec3", RandomNumbersGenerate(0, 60) },
                { "Direction3", 1 }
            };
            return randomDictionary;
        }
        private int RandomNumbersGenerate(int from, int to)
        {
            return _rnd.Next(from, to);
        }
    }
}
