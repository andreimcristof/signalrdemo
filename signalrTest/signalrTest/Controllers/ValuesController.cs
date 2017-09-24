using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace signalrTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IHubContext<Chat> _hubContext;
        public ValuesController(IHubContext<Chat> hubContext)
        {
            this._hubContext = hubContext;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id)
        {
            await _hubContext.Clients.All.InvokeAsync("Send", $"sent with id: {id}");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
