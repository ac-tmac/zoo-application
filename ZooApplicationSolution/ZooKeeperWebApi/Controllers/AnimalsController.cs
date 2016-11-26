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
            return zooKeeperDb.Animals.OrderBy(x => x.Name);
        }
    }
}
