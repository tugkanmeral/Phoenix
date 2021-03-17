using Microsoft.EntityFrameworkCore;
using Phoenix.LayerBases.DataAccess;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess
{
    public class DatabaseContext : DbContextBase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}
