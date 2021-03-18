using Phoenix.Attributes;
using Phoenix.LayerBases.Business;
using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.DataAccess;
using Phoenix.Live.DataAccess.Abstraction;
using Phoenix.Live.Entity;
using System.Linq;

namespace Phoenix.Live.Business.Concretes
{
    public class PasswordManager : ServiceBase<Password, int>, IPasswordService
    {
        public PasswordManager(IPasswordRepository passwordRepository) : base(passwordRepository)
        {
        }
    }
}
