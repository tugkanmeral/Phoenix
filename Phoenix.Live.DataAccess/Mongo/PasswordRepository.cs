using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.DataAccess.Abstraction.Mongo;
using Phoenix.Live.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Live.DataAccess.Mongo
{
    public class PasswordRepository : MongoRepositoryBase<Password>, IPasswordRepository
    {
        public PasswordRepository(MongoDbContext mongoContext) : base(mongoContext)
        {

        }
    }
}
