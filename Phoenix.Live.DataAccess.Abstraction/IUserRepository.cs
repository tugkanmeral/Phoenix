using Phoenix.LayerBases.DataAccess;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.Abstraction
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
