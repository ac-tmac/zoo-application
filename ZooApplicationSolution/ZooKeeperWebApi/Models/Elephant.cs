using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Elephant : Animal, IPreditor
    {
        public override AnimalTypeEnum Type
        {
            get
            {
                return AnimalTypeEnum.Mammal;
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