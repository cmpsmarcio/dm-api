using dm_api.Application.Dtos;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
using dm_api.Domain.Entities;
using dm_api.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dm_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;
        private readonly IApplicationServiceToken _applicationServiceToken;

        public AuthenticationController(IApplicationServiceUser applicationServiceUser, IApplicationServiceToken applicationServiceToken)
        {
            this._applicationServiceUser = applicationServiceUser;
            this._applicationServiceToken = applicationServiceToken;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authentication([FromBody] UserRequest userRequest)
        {
            try
            {
                User user = _applicationServiceUser.GetUser(userRequest.Username, userRequest.Password);

                if (user == null)
                    return BadRequest(new { message = "Invalid user" });

                var token = _applicationServiceToken.GenerateToken(user);

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
