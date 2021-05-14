using Phoenix.LayerBases.DataAccess.EntityFramework;
using Phoenix.Live.Entity;

namespace Phoenix.Live.DataAccess.Abstraction.EntityFramework
{
    public interface IPasswordRepository : IEfRepository<Password, int>
    {
    }
}
