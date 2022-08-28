using dm_api.Application.Dtos;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
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
        public ActionResult<IEnumerable<ClientResponse>> Get()
        {
            return Ok(_applicationServiceClient.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ClientResponse> Get(Guid id)
        {
            return Ok(_applicationServiceClient.Get(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClientRequest client)
        {
            try
            {
                if (client == null)
                    return BadRequest();

                _applicationServiceClient.Add(client);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ClientRequest client)
        {
            try
            {
                if (client == null)
                    return BadRequest();

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
        public ActionResult Delete(Guid id)
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
