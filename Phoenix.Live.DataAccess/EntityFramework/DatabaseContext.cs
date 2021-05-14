using Microsoft.EntityFrameworkCore;
using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.EntityFramework
{
    public class DatabaseContext : DbContextBase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}
