using Core.Infrastructure.Interfaces.Logging;
using Core.Service.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Admin.Service.Controllers
{
    [RequireHttps]
    [System.Web.Http.RoutePrefix("participation")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ParticipationController : ApiController
    {
        private readonly IParticipationService _participationService;
        private readonly ILoggingProvider _logger;

        public ParticipationController(
            IParticipationService participationService,
            ILoggingProvider logger
            )
        {
            _participationService = participationService;
            _logger = logger;
        }

        [System.Web.Http.Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}