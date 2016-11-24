using System;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.DTOs
{
    public class AnimalDTO : IAnimalDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}