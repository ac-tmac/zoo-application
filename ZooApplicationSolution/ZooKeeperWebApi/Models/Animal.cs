using System;
using ZooKeeperWebApi.Interfaces;
using ZooKeeperWebApi.Enums;
using System.Collections.Generic;

namespace ZooKeeperWebApi.Models
{
    public abstract class Animal : IAnimal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual AnimalType Type { get; set; }
        public string AnimalTypeString
        {
            get
            {
                return Type.ToString();
            }
            set
            {
                AnimalType type;
                if (Enum.TryParse(value, out type))
                {
                    Type = type;
                }
            }
        }

        public virtual IEnumerable<IAnimalBehaviour> Behaviours { get; set; }
    }
}