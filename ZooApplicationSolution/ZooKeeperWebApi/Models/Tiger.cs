using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Tiger : AnimalBase, IPreditor
    {
        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Mammal;
            }
        }

        public bool IsPreditor
        {
            get
            {
                return true;
            }
        }
    }
}