using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ZooKeeperWebApi.Interfaces;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalFamiliesController : ApiController
    {
        public IHttpActionResult Get()
        {
            var animalFamilies = new List<IAnimalFamilyDTO>();
            var familyNames = System.Reflection.Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => t.IsSubclassOf(typeof(Animal)) && !t.IsAbstract)
                            .Select(x => x.Name);

            foreach(var familyName in familyNames)
            {
                var animalFamily = new AnimalFamilyDTO
                {
                    Id = familyName,
                    Name = familyName
                };

                animalFamilies.Add(animalFamily);
            }

            return Ok(animalFamilies);
        }

    }
}
