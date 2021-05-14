using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.Abstraction.EntityFramework
{
    public abstract class PasswordRepositoryBase : EfRepositoryBase<Password, int>
    {
        public PasswordRepositoryBase(DbContextBase context) : base(context)
        {

        }

        public Password GetPasswordWithMask(int id)
        {
            Password pass = Get(p => p.Id == id);
            pass.Pass = "***";
            return pass;
        }
    }
}
