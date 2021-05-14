using MongoDB.Bson;
using Phoenix.LayerBases.Business;
using Phoenix.Live.Entity;

namespace Phoenix.Live.Business.Abstraction
{
    public interface IUserService : IService<User>
    {
        User GetUserFromMongo(ObjectId id);
        void TryAtomicProcess(User user);
        void InsertUserToMongo(User user);
        void ReplaceUserAtMongo(User user);
        void DeleteUserFromMongo(User user);
    }
}