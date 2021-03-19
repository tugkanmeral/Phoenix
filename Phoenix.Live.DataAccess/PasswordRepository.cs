using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        ///  Use this constructor to take advantage of UoW of DbContext which provided by EntityFrameworkCore
        /// </summary>
        /// <param name="dbContext">DatabaseContext</param>
        public PasswordRepository(DatabaseContext dbContext) : base(dbContext)
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
