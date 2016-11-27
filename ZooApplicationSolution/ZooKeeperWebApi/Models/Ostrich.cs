using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Ostrich : Animal, IFlyable
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
                return false;
            }

            private set { }
        }
    }
}