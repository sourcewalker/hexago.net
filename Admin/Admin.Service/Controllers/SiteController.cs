using Admin.Service.Models;
using Core.Service.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Admin.Service.Controllers
{
    //[RequireHttps]
    [System.Web.Http.RoutePrefix("site")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SiteController : ApiController
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
        public IHttpActionResult Get()
        {
            dynamic expando = new ExpandoObject();

            var apiResponse = new ApiResponse
            {
                Success = false,
                Message = "Bad Request",
                Data = expando
            };

            try
            {
                var startDate = DateTime.MinValue;

                if (!string.IsNullOrEmpty(from))
                {
                    if (DateTime.TryParse(from, out var startOut))
                    {
                        startDate = startOut;
                    }
                    else
                    {
                        _logger.LogWarn("Extract Error", $"On {DateTime.UtcNow.ToString()}");

                        expando.Error = new List<string>() { "Start date invalid: Please enter a valid date" };
                        apiResponse.Message = "Validation error occured";
                        apiResponse.Data = expando;

                        return Content(HttpStatusCode.BadRequest, apiResponse);
                    }
                }

                var endDate = DateTime.MaxValue;

                if (!string.IsNullOrEmpty(to))
                {
                    if (DateTime.TryParse(to, out var endOut))
                    {
                        endDate = endOut;
                    }
                    else
                    {
                        _logger.LogWarn("Extract Error", $"On {DateTime.UtcNow.ToString()}");

                        expando.Error = "End date invalid: Please enter a valid date";
                        apiResponse.Message = "Validation error occured";
                        apiResponse.Data = expando;

                        return Content(HttpStatusCode.BadRequest, apiResponse);
                    }
                }

                if (endDate.TimeOfDay.TotalSeconds == 0)
                    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

                expando.Export = _surveyService.ExtractParticipation(startDate, endDate);

                apiResponse.Success = true;
                apiResponse.Message = "Extracted successfully";
                apiResponse.Data = expando;

                _logger.LogWarn("Extract Success", $"On {DateTime.UtcNow.ToString()}");

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                expando = new ExpandoObject();
                expando.Error = e.Message;

                apiResponse.Success = false;
                apiResponse.Message = $"Error occured in {e.Source}";
                apiResponse.Data = expando;

                _logger.LogError(e.Message, e);

                return Content(HttpStatusCode.InternalServerError, apiResponse);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("[id]")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
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
