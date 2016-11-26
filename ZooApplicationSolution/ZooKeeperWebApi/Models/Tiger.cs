﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public bool IsPreditor
        {
            get
            {
                return true;
            }
        }
    }
}