using Phoenix.Attributes;
using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.Live.DataAccess.Abstraction.EntityFramework;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.EntityFramework
{
    public partial class UserRepository : EfRepositoryBase<User, int>, IUserRepository
    {
        /// <summary>
        ///  Use this constructor to take advantage of UoW of DbContext which provided by EntityFrameworkCore
        /// </summary>
        /// <param name="dbContext">DatabaseContext</param>
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
