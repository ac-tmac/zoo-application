using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooKeeperWebApi.Enums;

namespace ZooKeeperWebApi.Interfaces
{
    public interface IAnimalClassifier: IAnimal, IFlyable, IPreditor
    {
        AnimalType AnimalType { get; }
    }
}
