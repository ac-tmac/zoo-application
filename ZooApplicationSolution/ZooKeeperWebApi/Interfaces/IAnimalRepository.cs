using System;

namespace ZooKeeperWebApi.Interfaces
{
    interface IAnimalRepository
    {
        IAnimal Get(Guid id);
        void Add(IAnimal animal);
        void Update(IAnimal animal);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
