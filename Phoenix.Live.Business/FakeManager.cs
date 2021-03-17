using Phoenix.Aspects.Logging;
using Phoenix.Live.Business.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Live.Business.Concretes
{
    public class FakeManager : IFakeService
    {
        public string ReturnMessage()
        {
            return "TUGKAN";
        }
    }
}
