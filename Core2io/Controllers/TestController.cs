using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;

namespace Core2io.Controllers
{
    [Route("core2io/api/[controller]")]
    public class TestController : Controller
    {
        public TestController(ILogger<TestController> logger)
        {
            if (null != logger)
            {
                _logger = logger;
            }
        }
        protected readonly ILogger<TestController> _logger;

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //ILogger _logger;
            _logger.LogDebug("We're going to throw an exception now.");
            _logger.LogWarning("It's gonna happen!!");
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
