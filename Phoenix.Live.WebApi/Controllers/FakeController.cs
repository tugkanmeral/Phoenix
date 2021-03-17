using Microsoft.AspNetCore.Mvc;
using Phoenix.Live.Business.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Phoenix.Live.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeController : ControllerBase
    {
        IFakeService _fakeService;
        public FakeController(IFakeService fakeService)
        {
            _fakeService = fakeService;
        }

        // GET api/<fakeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _fakeService.ReturnMessage();
        }

    }
}
