using Phoenix.Aspects.Logging;
using Phoenix.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Live.Business.Abstraction
{
    [UseProxy]
    public interface IFakeService
    {
        [LogAspect]
        string ReturnMessage();
    }
}
