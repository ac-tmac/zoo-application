using System;
using System.Web.Http;
using ZooKeeperWebApi.Models;
using ZooKeeperWebApi.Interfaces;
using System.Net;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalController : ApiController
    {
        ZooKeeperDbContext zooKeeperDb = new ZooKeeperDbContext();
        private IAnimalRepository respositry;

        public AnimalController()
        {
            this.respositry = new AnimalRepository(zooKeeperDb);
        }

        public IHttpActionResult Get(Guid id)
        {
            var animal = this.respositry.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            var animalDTO = new AnimalDTO();
            Map(animal, animalDTO);

            return Ok(animalDTO);
        }

        private void Map(IAnimalDTO dto, IAnimal model)
        {
            if (dto.Id.HasValue)
            {
                model.Id = dto.Id.Value;
            }
            model.Name = dto.Name;
            model.DateOfBirth = dto.DateOfBirth.Date;
        }

        private void Map(IAnimal model, IAnimalDTO dto)
        {
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.DateOfBirth = model.DateOfBirth.Date;
            dto.FamilyName = model.GetType().Name;
        }

        public IHttpActionResult Post(AnimalDTO animalDTO)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, animalDTO);
            }
            
            var animalFactory = new AnimalFactory();
            var animal = animalFactory.Get(animalDTO.FamilyName);
            Map(animalDTO, animal);

            animal.Id = Guid.NewGuid();
            this.respositry.Add(animal);

            return Ok(animal.Id.ToString());
        }

        public IHttpActionResult Put(Guid id, AnimalDTO animalDTO)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, animalDTO);
            }

            var animal = this.respositry.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            animalDTO.Id = id;
            Map(animalDTO, animal);

            this.respositry.Update(animal);

            return Ok();
        }

        public IHttpActionResult Delete(Guid id)
        {
            if (!this.respositry.Exists(id))
            {
                return NotFound();
            }

            this.respositry.Delete(id);
            return Ok();
        }
    }
}
