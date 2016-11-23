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

        public Animal Get(Guid id = default(Guid))
        {
            var animal = zooKeeperDb.Animals.FirstOrDefault();
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
            return animal.Id.ToString();

        }
    }
}
