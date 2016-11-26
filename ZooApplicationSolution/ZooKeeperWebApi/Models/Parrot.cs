﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Parrot : AnimalBase, IFlyable
    {
        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Bird;
            }
        }

        bool IFlyable.CanFly
        {
            get
            {
                return true;
            }
        }
    }
}