using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalController : ApiController
    {
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
                return animal.Name + animal.DateOfBirth + "INVALID";
            }

            animal.Id = Guid.NewGuid();
            animal.DateOfBirth = animal.DateOfBirth.Date;

            zooKeeperDb.Entry(animal).State = System.Data.Entity.EntityState.Added;
            zooKeeperDb.SaveChanges();

            return animal.Name + ", " + animal.DateOfBirth.ToString();
        }

        public string Put(Guid id, Animal animal)
        {
            animal.Id = id;
            zooKeeperDb.Entry(animal).State = System.Data.Entity.EntityState.Modified;

            return animal.Name + ", " + animal.DateOfBirth.ToString();
        }
    }
}
