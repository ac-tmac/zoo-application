using System;
using System.Collections.Generic;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalFactory
    {
        public IAnimal Get(string familyName)
        {
            var type = Type.GetType(string.Format("ZooKeeperWebApi.Models.{0}", familyName));
            var animal = (Animal)Activator.CreateInstance(type);
            return animal;
        }
    }
}