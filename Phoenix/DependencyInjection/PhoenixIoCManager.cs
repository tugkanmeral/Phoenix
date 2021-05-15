using Microsoft.Extensions.DependencyInjection;
using Phoenix.Attributes;
using Phoenix.Proxy;
using System;
using System.Linq;
using System.Text;

namespace Phoenix.DependencyInjection
{
    public static class PhoenixIoCManager
    {
        public static void RegisterSingleton<TService, TImplementation>(this IServiceCollection services)
        {
            RegisterService<TService, TImplementation>(services, ServiceLifetime.Singleton);
        }

        public static void RegisterScoped<TService, TImplementation>(this IServiceCollection services)
        {
            RegisterService<TService, TImplementation>(services, ServiceLifetime.Scoped);            
        }

        public static void RegisterTransient<TService, TImplementation>(this IServiceCollection services)
        {
            RegisterService<TService, TImplementation>(services, ServiceLifetime.Transient);
        }

        private static void RegisterService<TService, TImplementation>(IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            var attrs = typeof(TService).GetCustomAttributes(false);
            var isProxy = attrs.Any(a => a.GetType() == typeof(UseProxyAttribute));

            if (isProxy)
                AddWithProxy<TService, TImplementation>(services, serviceLifetime);
            else
                Add<TService, TImplementation>(services, serviceLifetime);
        }

        private static void AddWithProxy<TService, TImplementation>(IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            //object instance = Activator.CreateInstance(typeof(TImplementation));
            //var service = new ServiceDescriptor(typeof(TService), DecoratedFactory, serviceLifetime);
            //services.Add(service);

            //object DecoratedFactory(IServiceProvider serviceProvider)
            //{
            //    var implementation = PhoenixProxyDispatcher<TService>.Resolve((TService)instance);

            //    return implementation;
            //}

            var descriptor = ServiceDescriptor.Describe(
                typeof(TService),
                sp =>
                {
                    return PhoenixProxyDispatcher<TService>.Resolve(
                                (TService)ActivatorUtilities.GetServiceOrCreateInstance(sp, typeof(TImplementation))
                            );
                },
                serviceLifetime);

            services.Add(descriptor);
        }

        private static void Add<TService, TImplementation>(IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            var service = new ServiceDescriptor(typeof(TService), typeof(TImplementation), serviceLifetime);
            services.Add(service);
        }
    }
}
