using System.Linq;
using System.Web.Http;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalFamiliesController : ApiController
    {
        public IHttpActionResult Get()
        {
            var familes = System.Reflection.Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => t.IsSubclassOf(typeof(Animal)) && !t.IsAbstract)
                            .Select(x => x.Name);

            return Ok(familes);
        }

    }
}
