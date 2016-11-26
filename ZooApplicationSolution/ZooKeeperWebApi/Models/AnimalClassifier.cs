using System;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalClassifier : AnimalBase, IAnimalClassifier
    {
        AnimalType animalType;

        public AnimalClassifier(AnimalType animalType)
        {
            this.animalType = animalType;
        }

        public override AnimalType AnimalType
        {
            get
            {
                return animalType;
            }
        }

        public bool CanFly { get; set; }
        public bool IsPreditor { get; set; }
    }
}