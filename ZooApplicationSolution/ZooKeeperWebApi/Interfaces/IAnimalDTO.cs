using System;

namespace ZooKeeperWebApi.Interfaces
{
    public interface IAnimalDTO
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
