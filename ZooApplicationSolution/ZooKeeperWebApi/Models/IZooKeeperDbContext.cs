using System.Data.Entity;
using ZooKeeperWebApi.Models;

namespace ZooKeeperWebApi.Interfaces
{
    public interface IZooKeeperDbContext
    {
        IDbSet<Animal> Animals { get; set; }
    }
}