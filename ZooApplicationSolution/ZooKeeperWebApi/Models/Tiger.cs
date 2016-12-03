using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Tiger : Animal, IPreditor
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
                return true;
            }

            private set { }
        }
    }
}