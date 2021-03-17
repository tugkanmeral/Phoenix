using Phoenix.Attributes;
using Phoenix.LayerBases.DataAccess;
using Phoenix.Live.DataAccess.Abstraction;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository() : base(new DatabaseContext())
        {

        }
    }
}
