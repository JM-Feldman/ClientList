using ClientDataCapture_API.Models;
using ClientDataCapture_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientDataCapture_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        //GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        //POST: api/Client
        [HttpPost]
        public ActionResult AddClient([FromBody] Client client)
        {
            _clientService.AddClient(client);
            return Ok(client);
        }

        //PUT: api/Client/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, [FromBody] Client client)
        {
            client.ClientId = id;
            _clientService.UpdateClient(client);
            return Ok();
        }

        //DELETE: api/Client/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
