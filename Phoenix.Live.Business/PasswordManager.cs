using Phoenix.Attributes;
using Phoenix.LayerBases.Business;
using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.DataAccess;
using Mongo = Phoenix.Live.DataAccess.Abstraction.Mongo;
using EF = Phoenix.Live.DataAccess.Abstraction.EntityFramework;
using Phoenix.Live.Entity;
using System.Linq;

namespace Phoenix.Live.Business.Concretes
{
    public class PasswordManager : ServiceBase<Password, int>, IPasswordService
    {
        public PasswordManager(Mongo.IPasswordRepository passwordRepository) : base(passwordRepository)
        {
        }

        public PasswordManager(EF.IPasswordRepository passwordRepository) : base(passwordRepository)
        {
        }

        public string Teststring = "";

        public string ReturnMessage()
        {
            return Teststring;
        }
    }
}
