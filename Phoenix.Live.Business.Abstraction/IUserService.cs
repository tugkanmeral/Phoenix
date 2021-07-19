using MongoDB.Bson;
using Phoenix.Attributes;
using Phoenix.LayerBases.Business;
using Phoenix.Live.Entity;

namespace Phoenix.Live.Business.Abstraction
{
    [UseProxy]
    public interface IUserService : IService<User>
    {
        User GetUserFromMongo(string id);
        void TryAtomicProcess(User user);
        void InsertUserToMongo(User user);
        void ReplaceUserAtMongo(User user);
        void DeleteUserFromMongo(User user);
    }
}