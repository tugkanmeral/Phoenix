using Phoenix.LayerBases.DataAccess;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.Abstraction
{
    public abstract class PasswordRepositoryBase : RepositoryBase<Password, int>
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
