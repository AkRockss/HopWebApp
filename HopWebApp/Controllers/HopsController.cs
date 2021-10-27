using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using HopClassLib;
using HopWebApp.Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.HttpOverrides;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HopWebApp.Controllers
{
    //[EnableCors()]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HopsController : ControllerBase
    {

        private readonly HopsManager _manager = new HopsManager();


        // GET: api/<HopsController>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<Hop> GetAll()
        {
            return _manager.GetAll();
        }

        // GET api/<HopsController>/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public Hop GetById(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<HopsController>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Hop Post([Microsoft.AspNetCore.Mvc.FromBody] Hop value)
        {
            return _manager.Add(value);
        }

        // DELETE api/<HopsController>/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public Hop Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}

