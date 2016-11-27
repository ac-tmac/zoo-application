using System;
using ZooKeeperWebApi.Enums;

namespace ZooKeeperWebApi.Interfaces
{
    public interface IAnimal
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        AnimalType AnimalType { get; }
    }
}
