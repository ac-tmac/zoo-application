using System;
using System.Linq;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalRepository : IAnimalRepository
    {
        private ZooKeeperDbContext zooKeeperDb;
        public AnimalRepository(ZooKeeperDbContext zooKeeperDb)
        {
            this.zooKeeperDb = zooKeeperDb;
        }

        public IAnimal Get(Guid id)
        {
            var animal = zooKeeperDb.Animals.SingleOrDefault(x => x.Id == id);
            return animal;
        }

        public void Add(IAnimal animal)
        {
            zooKeeperDb.Entry(animal).State = System.Data.Entity.EntityState.Added;
            zooKeeperDb.SaveChanges();
        }

        public void Update(IAnimal animal)
        {
            zooKeeperDb.Entry(animal).State = System.Data.Entity.EntityState.Modified;
            zooKeeperDb.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var animal = zooKeeperDb.Animals.Single(x => x.Id == id);
            zooKeeperDb.Animals.Remove(animal);
            zooKeeperDb.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            var exists = zooKeeperDb.Animals.Any(x => x.Id == id);
            return exists;
        }
    }
}