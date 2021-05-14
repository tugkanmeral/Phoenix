using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.Abstraction.EntityFramework
{
    public interface IUserRepository : IEfRepository<User, int>
    {
    }
}
