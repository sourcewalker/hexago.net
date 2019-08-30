using Admin.Service.Models;
using Core.Infrastructure.Interfaces.Logging;
using Core.Service.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Dynamic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Admin.Service.Controllers
{
    [RequireHttps]
    [System.Web.Http.RoutePrefix("site")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SiteController : ApiController
    {
        private readonly ISiteService _siteService;
        private readonly ILoggingProvider _logger;

        public SiteController(
            ISiteService siteService,
            ILoggingProvider logger)
        {
            _siteService = siteService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve site list organised by page
        /// </summary>
        /// <param name="pageNumber">Current page to retrieve</param>
        /// <param name="pageSize">Size of page</param>
        /// <remarks>
        /// Get Site list paged
        /// </remarks>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("paged")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
        public IHttpActionResult GetPaged(int pageNumber, int pageSize)
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

                expando.Sites = _siteService.GetSitesPaged(pageNumber, pageSize);

                apiResponse.Success = true;
                apiResponse.Message = "Site list returned successfully";
                apiResponse.Data = expando;

                //_logger.LogWarn("Sites Requested", $"On {DateTimeOffset.UtcNow.ToString()}");

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

        /// <summary>
        /// Retrieve site by Id
        /// </summary>
        /// <param name="id">Id of the site to retrieve</param>
        /// <remarks>
        /// Get Site by Id
        /// </remarks>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
        // GET api/values/5
        public IHttpActionResult Get(int id)
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

                apiResponse.Success = true;
                apiResponse.Message = "Site list returned successfully";
                apiResponse.Data = expando;

                //_logger.LogWarn("Sites Requested", $"On {DateTimeOffset.UtcNow.ToString()}");

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

        /// <summary>
        /// Create site
        /// </summary>
        /// <param name="site">Site to create</param>
        /// <remarks>
        /// Create
        /// </remarks>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("create")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
        public IHttpActionResult Post([FromBody]string site)
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

                apiResponse.Success = true;
                apiResponse.Message = "Site list returned successfully";
                apiResponse.Data = expando;

                //_logger.LogWarn("Sites Requested", $"On {DateTimeOffset.UtcNow.ToString()}");

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

        /// <summary>
        /// Edit site by Id
        /// </summary>
        /// <param name="id">Id of the site to update</param>
        /// <param name="site">Updated site</param>
        /// <remarks>
        /// Update Site by Id
        /// </remarks>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("update/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
        public IHttpActionResult Put(int id, [FromBody]string site)
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

                apiResponse.Success = true;
                apiResponse.Message = "Site list returned successfully";
                apiResponse.Data = expando;

                //_logger.LogWarn("Sites Requested", $"On {DateTimeOffset.UtcNow.ToString()}");

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

        /// <summary>
        /// Remove site by Id
        /// </summary>
        /// <param name="id">Id of the site to delete</param>
        /// <remarks>
        /// Delete Site by Id
        /// </remarks>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("delete/{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiResponse))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiResponse))]
        public IHttpActionResult Delete(int id)
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

                apiResponse.Success = true;
                apiResponse.Message = "Site list returned successfully";
                apiResponse.Data = expando;

                //_logger.LogWarn("Sites Requested", $"On {DateTimeOffset.UtcNow.ToString()}");

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
    }
}
