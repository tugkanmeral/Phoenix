using MongoDB.Bson;
using Phoenix.Attributes;
using Phoenix.LayerBases.Business;
using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.Business.Abstraction;
using EF = Phoenix.Live.DataAccess.Abstraction.EntityFramework;
using Mongo = Phoenix.Live.DataAccess.Abstraction.Mongo;
using Phoenix.Live.Entity;

namespace Phoenix.Live.Business.Concretes
{
    public class UserManager : ServiceBase<User, int>, IUserService
    {
        public UserManager(EF.IUserRepository userRepository) : base(userRepository)
        {
        }

        // Eğer IUserRepository cannot resolve benzeri bir hata alıyorsa bu constructor'ı yukarı çıkar o şekilde çözülüyor. Bunu düzelt!
        Mongo.IUserRepository _userRepository;
        public UserManager(Mongo.IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUserFromMongo(User user)
        {
            _userRepository.DeleteOne(u => u._id == user._id);
        }

        public User GetUserFromMongo(string id)
        {
            return _userRepository.Get(u => u._id == id);
        }

        public void InsertUserToMongo(User user)
        {
            _userRepository.Insert(user);
        }

        public void ReplaceUserAtMongo(User user)
        {
            _userRepository.ReplaceOne(u => u._id == user._id, user);
        }

        public void TryAtomicProcess(User user)
        {
            try
            {
                _userRepository.StartTransaction();

                _userRepository.InsertTransactional(user);
                User addedUser = _userRepository.GetTransactional(u => u.Username == user.Username);
                _userRepository.DeleteOneTransactional(u => u._id == addedUser._id);

                _userRepository.Commit();
            }
            catch (System.Exception ex)
            {
                _userRepository.RollBack();
                throw ex;
            }
            
        }
    }
}