using System;
using ZooKeeperWebApi.Interfaces;
using ZooKeeperWebApi.Enums;

namespace ZooKeeperWebApi.Models
{
    public abstract class Animal : IAnimal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual AnimalType AnimalType { get; set; }
    }
}