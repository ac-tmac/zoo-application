using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Tiger : Animal, IPreditor
    {
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
                return true;
            }

            private set { }
        }
    }
}