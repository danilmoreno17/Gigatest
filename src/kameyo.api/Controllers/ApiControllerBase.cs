using Kameyo.Core.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        protected ObjectResult BuildResponse<T>(ResultPaginated<T> appResponse)
        {
            ObjectResult result;
            switch (appResponse.Status)
            {
                case HttpStatusCode.OK:
                    result = Ok(appResponse);
                    break;
                case HttpStatusCode.NoContent:
                    result = StatusCode(204, appResponse);
                    break;
                case HttpStatusCode.Created:
                    result = Created("uri",appResponse.Data);
                    break;
                case HttpStatusCode.NotFound:
                    result = NotFound(appResponse);
                    break;
                case HttpStatusCode.PreconditionFailed:
                    result = StatusCode(412, appResponse);
                    break;
                default:
                    result = BadRequest(appResponse);
                    break;
            }

            return result;
        }

        protected ObjectResult BuildResponse<T>(Result<T> appResponse)
        {
            ObjectResult result;
            switch (appResponse.Status)
            {
                case HttpStatusCode.OK:
                    result = Ok(appResponse);
                    break;
                case HttpStatusCode.NoContent:
                    result = StatusCode(204, appResponse); 
                    break;
                case HttpStatusCode.Created:
                    result = Created("uri", appResponse.Data);
                    break;
                case HttpStatusCode.NotFound:
                    result = NotFound(appResponse);
                    break;
                case HttpStatusCode.PreconditionFailed:
                    result = StatusCode(412, appResponse);
                    break;
                default:
                    result = BadRequest(appResponse);
                    break;
            }

            return result;
        }

        protected ObjectResult BuildResponse(LoadResultModel appResponse)
        {
            ObjectResult result;
            switch (appResponse.Status)
            {
                case HttpStatusCode.OK:
                    result = Ok(appResponse);
                    break;
                case HttpStatusCode.Created:
                    result = Created("uri", appResponse.Data);
                    break;
                case HttpStatusCode.NotFound:
                    result = NotFound(appResponse);
                    break;
                case HttpStatusCode.PreconditionFailed:
                    result = StatusCode(412, appResponse);
                    break;
                default:
                    result = BadRequest(appResponse);
                    break;
            }

            return result;
        }

    }
}
