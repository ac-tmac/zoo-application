using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Parrot : Animal, IFlyable
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
                return true;
            }

            private set { }
        }
    }
}