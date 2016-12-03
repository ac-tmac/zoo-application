using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Ostrich : Animal, IFlyable
    {
        public override AnimalTypeEnum Type
        {
            get
            {
                return AnimalTypeEnum.Bird;
            }
        }

        public bool CanFly
        {
            get
            {
                return false;
            }

            private set { }
        }
    }
}