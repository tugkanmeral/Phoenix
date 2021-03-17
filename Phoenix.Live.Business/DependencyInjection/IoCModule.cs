using Autofac;
using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.Business.Concretes;
using Phoenix.Live.DataAccess;
using Phoenix.Live.DataAccess.Abstraction;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.DependencyInjection;

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
        }
    }
}
