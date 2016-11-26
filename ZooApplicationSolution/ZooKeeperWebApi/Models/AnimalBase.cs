using System;
using System.ComponentModel.DataAnnotations;
using ZooKeeperWebApi.Interfaces;
using ZooKeeperWebApi.Enums;

namespace ZooKeeperWebApi.Models
{
    public abstract class AnimalBase : IAnimal
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public abstract AnimalType AnimalType { get; }
    }
}