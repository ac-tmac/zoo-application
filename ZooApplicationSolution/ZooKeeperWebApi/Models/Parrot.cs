using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Parrot : Animal, IFlyable
    {
        public override AnimalType Type
        {
            get
            {
                return AnimalType.Bird;
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