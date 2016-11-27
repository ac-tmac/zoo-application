using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Elephant : Animal, IPreditor
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
                return false;
            }

            private set { }
        }
    }
}