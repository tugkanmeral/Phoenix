using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.DataAccess.Abstraction.Mongo;
using Phoenix.Live.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Live.DataAccess.Mongo
{
    public class UserRepository : MongoRepositoryBase<User>, IUserRepository
    {
        public UserRepository(MongoDbContext mongoContext) : base(mongoContext)
        {

        }
    }
}
