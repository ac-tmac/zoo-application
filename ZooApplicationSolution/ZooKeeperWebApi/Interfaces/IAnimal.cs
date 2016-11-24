using System;

namespace ZooKeeperWebApi.Interfaces
{
    public interface IAnimal
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
