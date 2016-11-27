using System;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalProfile : IAnimalProfile
    {
        AnimalType animalType;

        public AnimalProfile(AnimalType animalType)
        {
            this.animalType = animalType;
        }

        public AnimalType Type
        {
            get
            {
                return animalType;
            }
        }

        public bool CanFly { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid Id { get; set; }
        public bool IsPreditor { get; set; }
        public string Name { get; set; }
    }
}