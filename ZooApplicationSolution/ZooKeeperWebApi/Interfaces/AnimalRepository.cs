using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Interfaces
{
    public class AnimalRepository
    {
        private ZooKeeperDbContext zooKeeperDb;
        public AnimalRepository(ZooKeeperDbContext zooKeeperDb)
        {
            this.zooKeeperDb = zooKeeperDb;
        }

        public Animal Get(Guid id)
        {
            var animal = zooKeeperDb.Animals.SingleOrDefault(x => x.Id == id);
            return animal;
        }
    }
}