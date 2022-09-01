using dm_api.Application.Dtos;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dm_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IApplicationServiceToken _applicationServiceToken;

        public AuthenticationController(IApplicationServiceToken applicationServiceToken)
        {
            this._applicationServiceToken = applicationServiceToken;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authentication([FromBody] UserRequest userRequest)
        {
            try
            {
                var token = _applicationServiceToken.GenerateToken(userRequest);

                return Ok(new
                {
                    token,
                });
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = ex.Message });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
