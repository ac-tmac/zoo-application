using System;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalFactory
    {
        public IAnimal Get(string familyName)
        {
            var type = Type.GetType(string.Format("ZooKeeperWebApi.Models.{0}", familyName));
            return (Animal)Activator.CreateInstance(type); 
        }
    }
}