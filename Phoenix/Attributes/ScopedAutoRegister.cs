using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedAutoRegister : Attribute
    {
        public ScopedAutoRegister(Type service)
        {

        }
    }
}
