using System.ComponentModel.DataAnnotations.Schema;
using ZooKeeperWebApi.Enums;
using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class Elephant : AnimalBase, IPreditor
    {
        public override AnimalType AnimalType
        {
            get
            {
                return AnimalType.Mammal;
            }
        }

        [NotMapped]
        public bool IsPreditor
        {
            get
            {
                return true;
            }
        }
    }
}