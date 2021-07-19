using Microsoft.AspNetCore.Mvc;
using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Phoenix.Live.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoTestController : ControllerBase
    {
        IUserService _userService;
        public MongoTestController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<MongoTestController>/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userService.GetUserFromMongo(id);
        }

        // POST api/<MongoTestController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.InsertUserToMongo(user);
        }

        // PUT api/<MongoTestController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            _userService.ReplaceUserAtMongo(user);
        }

        // DELETE api/<MongoTestController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            User user = _userService.GetUserFromMongo(id);
            _userService.DeleteUserFromMongo(user);
        }

        // POST api/<MongoTestController>
        [HttpPost("TryAtomicProcess")]
        public void TryAtomicProcess([FromBody] User user)
        {
            _userService.TryAtomicProcess(user);
        }
    }
}
