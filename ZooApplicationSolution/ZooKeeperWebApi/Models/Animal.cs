using System;
using System.ComponentModel.DataAnnotations;
using ZooKeeperWebApi.Enums;

namespace ZooKeeperWebApi.Models
{
    public class Animal : AnimalBase
    {
        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Undefined;
            }
        }
    }
}