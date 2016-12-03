using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ZooKeeperWebApi.Models
{
    public class ZooKeeperEntitiesInitialiser : DropCreateDatabaseIfModelChanges<ZooKeeperEntities>
    {
        protected override void Seed(ZooKeeperEntities entities)
        {
            entities.AnimalTypes.AddOrUpdate(x => x.Id,
                new AnimalType() { Id = 1, Name = "Bird" },
                new AnimalType() { Id = 1, Name = "Mamal" }
            );
        }
    }
}