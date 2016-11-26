using System.ComponentModel.DataAnnotations.Schema;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Ostrich : AnimalBase, IFlyable
    {
        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Bird;
            }
        }

        [NotMapped]
        bool IFlyable.CanFly
        {
            get
            {
                return false;
            }

        }
    }
}