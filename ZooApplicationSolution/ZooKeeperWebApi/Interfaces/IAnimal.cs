using System;
using System.Collections.Generic;
using ZooKeeperWebApi.Enums;

namespace ZooKeeperWebApi.Interfaces
{
    public interface IAnimal
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        AnimalType Type { get; }
        IEnumerable<IAnimalBehaviour> Behaviours { get; set; }
    }
}
