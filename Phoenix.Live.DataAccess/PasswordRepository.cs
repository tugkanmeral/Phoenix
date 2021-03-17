using Phoenix.Attributes;
using Phoenix.LayerBases.DataAccess;
using Phoenix.Live.DataAccess.Abstraction;
using Phoenix.Live.Entity;
using System;
using System.Linq.Expressions;

namespace Phoenix.Live.DataAccess
{
    public class PasswordRepository : RepositoryBase<Password, int>, IPasswordRepository
    {
        public PasswordRepository() : base(new DatabaseContext())
        {

        }

        public override Password Get(Expression<Func<Password, bool>> filter)
        {
            var pass = base.Get(filter);
            pass.Pass = "****";
            return pass;
        }
    }
}
