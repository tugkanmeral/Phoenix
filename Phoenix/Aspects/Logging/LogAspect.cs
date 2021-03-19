using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Aspects.Logging
{
    [AttributeUsage((AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method), AllowMultiple = false)]
    public class LogAspect : Attribute
    {
    }
}
