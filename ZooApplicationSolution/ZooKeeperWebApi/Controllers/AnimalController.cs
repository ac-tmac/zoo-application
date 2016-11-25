﻿using System;
using System.Linq;
using System.Web.Http;
using ZooKeeperWebApi.Models;
using ZooKeeperWebApi.DTOs;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Controllers
{
    public class AnimalController : ApiController
    {
        // Each animal should share a common set of properties, only store their name, date of birth and type.

        //TODO: Demonstrate inheritance and abstraction    
        // we are only storing a small set of animal family characteristics, each species would have a number of unique traits, the need for animal families to be stored separately. 
        // https://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-3-table-per-concrete-type-tpc-and-choosing-strategy-guidelines

        ZooKeeperDbContext zooKeeperDb = new ZooKeeperDbContext();
        private IAnimalRepository respositry;

        public AnimalController()
        {
            this.respositry = new AnimalRepository(zooKeeperDb);
        }

        public IAnimalDTO Get(Guid id)
        {
            var animal = this.respositry.Get(id);

            var animalDTO = new AnimalDTO();
            Map(animal, animalDTO);

            return animalDTO;
        }

        private void Map(IAnimalDTO dto, IAnimal model)
        {
            model.Id = dto.Id;
            model.Name = dto.Name;
            model.DateOfBirth = dto.DateOfBirth.Date;
        }

        private void Map(IAnimal model, IAnimalDTO dto)
        {
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.DateOfBirth = model.DateOfBirth.Date;
        }
        
        public string Post(AnimalDTO animalDTO)
        {
            if (!ModelState.IsValid)
            {
                return "INVALID";
            }

            var animal = new Animal();
            Map(animalDTO, animal);
            this.respositry.Add(animal);

            return animal.Name + ", " + animal.DateOfBirth.ToString();
        }

        public string Put(Guid id, AnimalDTO animalDTO)
        {
            if (!ModelState.IsValid)
            {
                return "INVALID";
            }

            animalDTO.Id = id;

            if (!zooKeeperDb.Animals.Any(x => x.Id == id))
            {
                return id + ", " + "NOTFOUND";
            }

            var animal = new Animal();
            Map(animalDTO, animal);

            this.respositry.Update(animal);

            return animal.Name + ", " + animal.DateOfBirth.ToString();
        }

        public string Delete(Guid id)
        {
            if (!this.respositry.Exists(id))
            {
                return id + ", " + "NOTFOUND";
            }

            this.respositry.Delete(id);

            return "REMOVED";
        }
    }
}
