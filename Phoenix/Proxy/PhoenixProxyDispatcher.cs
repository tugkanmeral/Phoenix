using Microsoft.Extensions.DependencyInjection;
using Phoenix.Aspects.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Phoenix.Proxy
{
    public class PhoenixProxyDispatcher<T> : DispatchProxy
    {
        public T _decorated;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var customAttrs = targetMethod.CustomAttributes;
            var logAspect = customAttrs.Any(att => att.AttributeType == typeof(LogAspect));

            if (logAspect)
                Console.WriteLine($"{DateTime.Now} Before {targetMethod.Name} run");

            object result = null;
            try
            {
                result = targetMethod.Invoke(_decorated, args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} Exception: {ex.Message}");
            }

            if (logAspect)
                Console.WriteLine($"{DateTime.Now} After {targetMethod.Name} run");

            return result;
        }

        public static T Resolve(T decorated)
        {
            object proxy = Create<T, PhoenixProxyDispatcher<T>>();
            ((PhoenixProxyDispatcher<T>)proxy).SetParameters(decorated);

            return (T)proxy;
        }

        private void SetParameters(T decorated)
        {
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }
    }
}
