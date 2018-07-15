using Academy2018_.NET_Homework5.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy2018_.NET_Homework5.Infrastructure.Database
{
    public class AirportContext: DbContext
    {
        public AirportContext(): base()
        {        
            Database.Migrate();
            Database.EnsureCreated();
        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<AirplaneType> AirplaneTypes { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardesse> Stewardesses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AirportDB;Trusted_Connection=True;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
