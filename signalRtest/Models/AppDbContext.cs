using Microsoft.EntityFrameworkCore;

namespace signalRtest.Models
{
    public class AppDbContext :DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HUWAIE;Database=SignalRUdmy;Trusted_Connection=true;TrustServerCertificate=True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Team>Teams { get; set; }
    }
}
