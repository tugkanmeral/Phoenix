using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TransientAutoRegister : Attribute
    {
        public TransientAutoRegister(Type service)
        {

        }
    }
}
