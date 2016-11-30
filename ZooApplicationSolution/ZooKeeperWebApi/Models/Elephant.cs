using System.Collections.Generic;
using System.Linq;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Elephant : Animal, IPreditor
    {
        IList<IAnimalBehaviour> behaviours;

        public Elephant()
        {
            behaviours = new List<IAnimalBehaviour>() { new HuntBehaviour() };
        }

        public override AnimalType Type
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
                return behaviours.OfType<HuntBehaviour>().Any();
            }

            private set {
                if (value && !IsPreditor)
                {
                    behaviours.Add(new HuntBehaviour());
                }
            }
        }
    }
}