using System.Data.Entity;

namespace ZooKeeperWebApi.Models
{
    public class ZooKeeperDbContext : DbContext
    {
        public ZooKeeperDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<AnimalBase> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parrot>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Parrot");
            });

            modelBuilder.Entity<Ostrich>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Ostrich");
            });
            modelBuilder.Entity<Tiger>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Tiger");
            });

            modelBuilder.Entity<Elephant>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Elephant");
            });
        }
    }
}