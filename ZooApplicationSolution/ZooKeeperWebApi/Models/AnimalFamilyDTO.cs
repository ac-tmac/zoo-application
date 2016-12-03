using ZooKeeperWebApi.Interfaces;

namespace ZooKeeperWebApi.Models
{
    public class AnimalFamilyDTO : IAnimalFamilyDTO
    {
        public string Id { get;set; }
        public string Name { get; set; }
    }
}