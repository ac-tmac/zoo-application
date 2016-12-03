using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ZooKeeperWebApi.Models
{
    public class ZooKeeperEntities : DbContext
    {
        public ZooKeeperEntities() : base("name=DefaultConnection")
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // modelBuilder.Entity<AnimalType>();
            modelBuilder.Entity<Animal>().Ignore(t => t.Type);


            modelBuilder.Entity<Parrot>().Map(m => m.ToTable("Parrot"));
            modelBuilder.Entity<Ostrich>().Map(m => m.ToTable("Ostrich"));
            modelBuilder.Entity<Tiger>().Map(m => m.ToTable("Tiger"));
            modelBuilder.Entity<Elephant>().Map(m => m.ToTable("Elephant"));

            base.OnModelCreating(modelBuilder);
        }
    }
}