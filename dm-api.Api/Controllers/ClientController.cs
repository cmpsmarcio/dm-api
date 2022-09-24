using dm_api.Application.Models;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dm_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IApplicationServiceClient _applicationServiceClient;

        public ClientController(IApplicationServiceClient applicationServiceClient)
        {
            _applicationServiceClient = applicationServiceClient;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ClientResponse>> Get()
        {
            return CreateResponse(() => _applicationServiceClient.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ClientResponse> Get(Guid id)
        {
            return CreateResponse(() => _applicationServiceClient.Get(id));
        }

        [HttpPost]
        [Authorize(Roles = "adm")]
        public ActionResult Post([FromBody] ClientRequest client)
        {
            if (client == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            return CreateResponse(() => _applicationServiceClient.Add(client));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public ActionResult Put(Guid id, [FromBody] ClientRequest client)
        {
            if (client == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            return CreateResponse(() => _applicationServiceClient.Update(id, client));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public ActionResult Delete(Guid id)
        {
            return CreateResponse(() => _applicationServiceClient.Delete(id));
        }
    }
}
