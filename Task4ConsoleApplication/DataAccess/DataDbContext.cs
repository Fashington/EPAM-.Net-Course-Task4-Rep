using System.Data.Entity;

namespace DataAccess
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() : base("DbConnectionString") { }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
