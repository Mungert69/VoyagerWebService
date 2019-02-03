using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorksVoyWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorksVoyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IPriceService _priceService;
        private ISessionObjectsService _sessionObjectsService;

        public ValuesController(ISessionObjectsService sessionObjectsService, IPriceService priceService)
        {
            _sessionObjectsService = sessionObjectsService;
            _priceService = priceService;
        }

        // GET api/values/AllPrices
        [HttpGet("AllPrices")]
        public ActionResult<string> GetAllPrices()
        {
           
            _priceService.SessionObject= _sessionObjectsService.getSessionObject(Guid.Parse("Admin"));
            return _priceService.updateItinTemplatePrices();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
