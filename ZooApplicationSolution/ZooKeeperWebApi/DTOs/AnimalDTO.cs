using System;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.DTOs
{
    public class AnimalDTO : IAnimalDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AnimalType Type { get; set; }
    }
}