using EntryControl.Models;
using Microsoft.EntityFrameworkCore;

namespace EntryControl.Data
{
    public class DataContext : DbContext
    {
        
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ReportEvent> ReportEvents { get; set; }
        public DbSet<ReportWorkHours> ReportWorkHours { get; set; }
        public DbSet<GateAccess> GateAccess { get; set; }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Database=EntryControlDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False,MultipleActiveResultSets=true");
            
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .ToTable("Workers");                        
            modelBuilder.Entity<Worker>()
                .HasData(
                    new Worker { Id = 1, WorkerId = 1, Name = "Carson", Surname = "Alexander", AuthorizationLevel = AuthorizationType.Administrator },
                    new Worker { Id = 2, WorkerId = 2, Name = "Meredith", Surname = "Alonso", AuthorizationLevel = AuthorizationType.Engineer },
                    new Worker { Id = 3, WorkerId = 3, Name = "Arturo", Surname = "Anand", AuthorizationLevel = AuthorizationType.Director },
                    new Worker { Id = 4, WorkerId = 4, Name = "Gytis", Surname = "Barzdukas", AuthorizationLevel = AuthorizationType.Worker },
                    new Worker { Id = 5, WorkerId = 5, Name = "Yan", Surname = "Li", AuthorizationLevel = AuthorizationType.Engineer },
                    new Worker { Id = 6, WorkerId = 6, Name = "Peggy", Surname = "Justice", AuthorizationLevel = AuthorizationType.Worker },
                    new Worker { Id = 7, WorkerId = 7, Name = "Laura", Surname = "Norman", AuthorizationLevel = AuthorizationType.Worker },
                    new Worker { Id = 8, WorkerId = 8, Name = "Nino", Surname = "Rustin", AuthorizationLevel = AuthorizationType.Worker },    
                    new Worker { Id = 9, WorkerId = 9, Name = "Jonas", Surname = "Petraitis", AuthorizationLevel = AuthorizationType.Worker },
                    new Worker { Id = 10, WorkerId = 10, Name = "Simonas", Surname = "Galinis", AuthorizationLevel = AuthorizationType.Worker }
                );
            modelBuilder.Entity<Gate>()
                .ToTable("Gates");
            modelBuilder.Entity<Gate>()
                .HasData(
                    new Gate { Id = 1, GateId = 1050, Name = GateName.Left, Description = "Lab" },
                    new Gate { Id = 2, GateId = 2030, Name = GateName.Main, Description = "Warehouse" },
                    new Gate { Id = 3, GateId = 2041, Name = GateName.Right, Description = "Office" },
                    new Gate { Id = 4, GateId = 1045, Name = GateName.Central, Description = "Central" }
                );
            modelBuilder.Entity<GateAccess>()
                .ToTable("GateAccess");
            modelBuilder.Entity<GateAccess>()
                .HasData(
                    new GateAccess { Id = 1, GateId = 1, AuthorizationType= AuthorizationType.Administrator, EventType= EventType.Allowed },
                    new GateAccess { Id = 2, GateId = 2, AuthorizationType = AuthorizationType.Administrator, EventType = EventType.Allowed },
                    new GateAccess { Id = 3, GateId = 3, AuthorizationType = AuthorizationType.Administrator, EventType = EventType.Allowed },
                    new GateAccess { Id = 4, GateId = 4, AuthorizationType = AuthorizationType.Administrator, EventType = EventType.Allowed },
                    new GateAccess { Id = 5, GateId = 1, AuthorizationType = AuthorizationType.Director, EventType = EventType.Allowed },
                    new GateAccess { Id = 6, GateId = 2, AuthorizationType = AuthorizationType.Director, EventType = EventType.Allowed },
                    new GateAccess { Id = 7, GateId = 3, AuthorizationType = AuthorizationType.Director, EventType = EventType.Allowed },
                    new GateAccess { Id = 8, GateId = 4, AuthorizationType = AuthorizationType.Director, EventType = EventType.Deny },
                    new GateAccess { Id = 9, GateId = 1, AuthorizationType = AuthorizationType.Engineer, EventType = EventType.Allowed },
                    new GateAccess { Id = 10, GateId = 2, AuthorizationType = AuthorizationType.Engineer, EventType = EventType.Deny },
                    new GateAccess { Id = 11, GateId = 3, AuthorizationType = AuthorizationType.Engineer, EventType = EventType.Allowed },
                    new GateAccess { Id = 12, GateId = 4, AuthorizationType = AuthorizationType.Engineer, EventType = EventType.Allowed },
                    new GateAccess { Id = 13, GateId = 1, AuthorizationType = AuthorizationType.Worker, EventType = EventType.Deny },
                    new GateAccess { Id = 14, GateId = 2, AuthorizationType = AuthorizationType.Worker, EventType = EventType.Deny },
                    new GateAccess { Id = 15, GateId = 3, AuthorizationType = AuthorizationType.Worker, EventType = EventType.Allowed },
                    new GateAccess { Id = 16, GateId = 4, AuthorizationType = AuthorizationType.Worker, EventType = EventType.Allowed }
                );
        }
        
    }
}
