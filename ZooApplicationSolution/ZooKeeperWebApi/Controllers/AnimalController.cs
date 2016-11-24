using System;
using System.Linq;
using System.Web.Http;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalController : ApiController
    {
        // Each animal should share a common set of properties, only store their name, date of birth and type.

        //TODO: Demonstrate inheritance and abstraction    
        // we are only storing a small set of animal family characteristics, each species would have a number of unique traits, the need for animal families to be stored separately. 
        // https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-3-table-per-concrete-type-tpc-and-choosing-strategy-guidelines

        ZooKeeperDbContext zooKeeperDb = new ZooKeeperDbContext();

        public Animal Get(Guid id)
        {
            var animal = zooKeeperDb.Animals.SingleOrDefault(x => x.Id == id);

            return animal;
        }


        public string Post(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return animal.Name + ", " + animal.DateOfBirth.ToString() + "INVALID";
            }

            animal.Id = Guid.NewGuid();
            animal.DateOfBirth = animal.DateOfBirth.Date;

            zooKeeperDb.Entry(animal).State = System.Data.Entity.EntityState.Added;
            zooKeeperDb.SaveChanges();

            return animal.Name + ", " + animal.DateOfBirth.ToString();
        }

        public string Put(Guid id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return animal.Id + ", " + animal.Name + ", " + animal.DateOfBirth.ToString() + "INVALID";
            }

            if (!zooKeeperDb.Animals.Any(x => x.Id == id))
            {
                return animal.Id + ", " + "NOTFOUND";
            }

            animal.Id = id;
            zooKeeperDb.Entry(animal).State = System.Data.Entity.EntityState.Modified;
            zooKeeperDb.SaveChanges();
            return animal.Name + ", " + animal.DateOfBirth.ToString();
        }

        public string Delete(Guid id)
        {
            var animal = zooKeeperDb.Animals.SingleOrDefault(x => x.Id == id);
            if (animal == null)
            {
                return animal.Id + ", " + "NOTFOUND";
            }

            zooKeeperDb.Animals.Remove(animal);
            zooKeeperDb.SaveChanges();
            return "REMOVED";
        }
    }
}
