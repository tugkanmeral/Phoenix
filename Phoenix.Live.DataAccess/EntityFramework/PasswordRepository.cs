using Microsoft.EntityFrameworkCore;
using Phoenix.Attributes;
using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.Live.DataAccess.Abstraction.EntityFramework;
using Phoenix.Live.Entity;
using System;
using System.Linq.Expressions;

namespace Phoenix.Live.DataAccess.EntityFramework
{
    public class PasswordRepository : EfRepositoryBase<Password, int>, IPasswordRepository
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
