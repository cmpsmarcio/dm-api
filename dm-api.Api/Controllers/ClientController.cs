using dm_api.Application.Dtos;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceClient.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            return Ok(_applicationServiceClient.Get(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                    return BadRequest();

                _applicationServiceClient.Add(clientDto);

                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                    return BadRequest();

                _applicationServiceClient.Update(clientDto);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                    return BadRequest();

                _applicationServiceClient.Delete(clientDto);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
