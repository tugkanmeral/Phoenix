using Microsoft.EntityFrameworkCore;
using Phoenix.Utils;

namespace Phoenix.LayerBases.DataAccess.EntityFramework
{
    public abstract partial class DbContextBase : DbContext
    {
        private string _connectionStringName;

        public DbContextBase(string connectionStringName = "ConnectionString")
        {
            _connectionStringName = connectionStringName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigGetter.GetSectionFromJson(_connectionStringName));
        }
    }
}