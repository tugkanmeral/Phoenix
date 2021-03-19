using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.Business.Concretes;
using Phoenix.Live.DataAccess;
using Phoenix.Live.DataAccess.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.DependencyInjection;
using Phoenix.LayerBases.DataAccess;

namespace Phoenix.Live.Business.DependencyInjection
{
    public class IoCModule
    {
        public IoCModule(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterSingleton<IUserRepository, UserRepository>();
            serviceCollection.RegisterSingleton<IPasswordRepository, PasswordRepository>();
            serviceCollection.RegisterTransient<IUserService, UserManager>();
            serviceCollection.RegisterTransient<IPasswordService, PasswordManager>();
            serviceCollection.RegisterTransient<IFakeService, FakeManager>();

            serviceCollection.AddDbContext<DatabaseContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
        }
    }
}
