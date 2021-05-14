using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.Business.Concretes;
using EF = Phoenix.Live.DataAccess.EntityFramework;
using Mongo = Phoenix.Live.DataAccess.Mongo;
using EFA = Phoenix.Live.DataAccess.Abstraction.EntityFramework;
using MongoA = Phoenix.Live.DataAccess.Abstraction.Mongo;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.DependencyInjection;
using Phoenix.Live.DataAccess.Abstraction;
using Phoenix.LayerBases.DataAccess.MongoDb;
using Phoenix.Live.DataAccess.Mongo;

namespace Phoenix.Live.Business.DependencyInjection
{
    public class IoCModule
    {
        public IoCModule(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new MongoDbContext());
            serviceCollection.RegisterScoped<MongoA.IUserRepository, Mongo.UserRepository>();
            serviceCollection.RegisterScoped<EFA.IPasswordRepository, EF.PasswordRepository>();
            serviceCollection.RegisterTransient<IUserService, UserManager>();
            serviceCollection.RegisterTransient<IPasswordService, PasswordManager>();
            serviceCollection.RegisterTransient<IFakeService, FakeManager>();

            serviceCollection.AddDbContext<EF.DatabaseContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
        }
    }
}
