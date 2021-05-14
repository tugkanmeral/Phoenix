using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Live.DataAccess.Abstraction.Mongo
{
    public interface IUserRepository : IMongoRepository<User>
    {
    }
}
