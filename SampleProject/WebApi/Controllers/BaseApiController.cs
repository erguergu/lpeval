using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {

        public HttpResponseMessage AlreadyExists(Guid id)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, $"Record with id {id} already exists.");
        }

        public HttpResponseMessage Found(object obj)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        public HttpResponseMessage Found()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DoesNotExist()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}