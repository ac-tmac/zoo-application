using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalsController : ApiController
    {
        ZooKeeperDbContext zooKeeperDb = new ZooKeeperDbContext();

        public IEnumerable<Animal> Get()
        {
            return zooKeeperDb.Animals.OrderBy(x => x.Name);
        }
    }
}
