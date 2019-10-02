using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelperModel;
using HelperRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        //private readonly IHelperConfiguration _helperConfiguration;
        private readonly IRepository<Users> _repository;

        //public UsersController( IHelperConfiguration helperConfiguration, IRepository<Users> repository)
        //{
        //    _helperConfiguration = helperConfiguration;
        //    _repository = repository;
        //}


        public UsersController(IRepository<Users> repository)
        {
            _repository = repository;

        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            var query = new JObject();
            return await _repository.FetchByQuery(query);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Users> Get(string id)
        {
            return await _repository.FetchById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
