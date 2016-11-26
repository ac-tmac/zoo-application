using System.Data.Entity;

namespace ZooKeeperWebApi.Models
{
    public class ZooKeeperDbContext : DbContext
    {
        public ZooKeeperDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<AnimalClassifier> Animals { get; set; }
    }
}