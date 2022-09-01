using dm_api.Application.Dtos;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dm_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IApplicationServiceClient _applicationServiceClient;

        public ClientController(IApplicationServiceClient applicationServiceClient)
        {
            _applicationServiceClient = applicationServiceClient;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ClientResponse>>> Get()
        {
            return Ok(_applicationServiceClient.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ClientResponse>> Get(Guid id)
        {
            return Ok(_applicationServiceClient.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "adm")]
        public async Task<ActionResult> Post([FromBody] ClientRequest client)
        {
            try
            {
                if (client == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);

                _applicationServiceClient.Add(client);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ClientRequest client)
        {
            try
            {
                if (client == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);

                _applicationServiceClient.Update(id, client);
                return Ok("Success");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            { 
                _applicationServiceClient.Delete(id);
                return Ok("Success");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
