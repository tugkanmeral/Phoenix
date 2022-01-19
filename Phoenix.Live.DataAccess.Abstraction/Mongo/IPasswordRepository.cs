using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Live.DataAccess.Abstraction.Mongo
{
    public interface IPasswordRepository : IMongoRepository<Password>
    {
    }
}
