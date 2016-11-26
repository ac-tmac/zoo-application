using System.Data.Entity;

namespace ZooKeeperWebApi.Models
{
    public class ZooKeeperDbContext : DbContext
    {
        public ZooKeeperDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<AnimalBase> Animals { get; set; }
        public DbSet<Parrot> Parrots { get; set; }
        public DbSet<Ostrich> Ostrich { get; set; }
        public DbSet<Tiger> Tiger { get; set; }
        public DbSet<Elephant> Elephant { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TPC (Table per Concreate Type)
            //modelBuilder.Entity<Parrot>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Parrot");
            //});

            //modelBuilder.Entity<Ostrich>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Ostrich");
            //});
            //modelBuilder.Entity<Tiger>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Tiger");
            //});

            //modelBuilder.Entity<Elephant>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Elephant");
            //});

            // TPT (Table per Type)
            //modelBuilder.Entity<AnimalBase>()
            //        .Map<Parrot>(m =>m.ToTable("Parrot").HasValue(1))
            //        .Map<Ostrich>(m =>m.ToTable("Ostrich").HasValue(1))
            //        .Map<Tiger>(m => m.ToTable("Tiger").HasValue(1))
            //        .Map<Elephant>(m => m.ToTable("Elephant").HasValue(1));
            
            base.OnModelCreating(modelBuilder);
        }
    }
}