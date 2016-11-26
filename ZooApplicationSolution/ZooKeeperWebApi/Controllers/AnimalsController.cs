using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ZooKeeperWebApi.Models;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalsController : ApiController
    {
        ZooKeeperDbContext zooKeeperDb = new ZooKeeperDbContext();

        public IEnumerable<IAnimal> Get()
        {
            //TODO: How to make this work?
            return zooKeeperDb.Animals.OrderBy(x => x.Name);


            //var parrots = zooKeeperDb.Parrots as IEnumerable<AnimalBase>;
            //var ostrichs = zooKeeperDb.Ostrich as IEnumerable<AnimalBase>;
            //var tigers = zooKeeperDb.Tiger as IEnumerable<AnimalBase>;
            //var elephants = zooKeeperDb.Elephant as IEnumerable<AnimalBase>;

            //var animals = new List<AnimalBase>();
            //animals.AddRange(parrots);
            //animals.AddRange(ostrichs);
            //animals.AddRange(tigers);
            //animals.AddRange(elephants);
            //return animals;
        }
    }
}
