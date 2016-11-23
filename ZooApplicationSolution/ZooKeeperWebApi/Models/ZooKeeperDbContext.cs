using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ZooKeeperWebApi.Models
{
    public class ZooKeeperDbContext : DbContext
    {
        public ZooKeeperDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Animal> Animals { get; set; }
    }
}