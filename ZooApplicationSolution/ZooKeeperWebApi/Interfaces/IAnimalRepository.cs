using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperWebApi.Interfaces
{
    interface IAnimalRepository
    {
        IAnimal Get(Guid id);
        void Add(IAnimal animal);
    }
}
