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

        /// <summary>
        ///  Use this constructor to take advantage of UoW of DbContext which provided by EntityFrameworkCore
        /// </summary>
        /// <param name="dbContext">DatabaseContext</param>
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
