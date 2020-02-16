using Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataBase.DataAccess
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
        }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}