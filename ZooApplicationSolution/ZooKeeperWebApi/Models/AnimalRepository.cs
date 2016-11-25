using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooKeeperWebApi.Models;
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
    }
}