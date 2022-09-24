using dm_api.Application.Models;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dm_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IApplicationServiceToken _applicationServiceToken;

        public AuthenticationController(IApplicationServiceToken applicationServiceToken)
        {
            this._applicationServiceToken = applicationServiceToken;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> Authentication([FromBody] UserRequest userRequest)
        {
            return CreateResponse(() => _applicationServiceToken.GenerateToken(userRequest));
        }
    }
}
