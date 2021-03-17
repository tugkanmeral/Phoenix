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
    public class PasswordsController : ControllerBase
    {
        private IPasswordService _passwordService;
        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        // GET: api/<PasswordsController>
        [HttpGet]
        public IEnumerable<Password> Get()
        {
            return _passwordService.GetList();
        }

        // GET api/<PasswordsController>/5
        [HttpGet("{id}")]
        public Password Get(int id)
        {
            return _passwordService.Get(p => p.Id == id);
        }

        // POST api/<PasswordsController>
        [HttpPost]
        public void Post([FromBody] Password pass)
        {
            _passwordService.Add(pass);
        }

        //// PUT api/<PasswordsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PasswordsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
