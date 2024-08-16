using ClientDataCapture_API.Models;
using ClientDataCapture_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientDataCapture_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        //GET: api/Address/client/{clientId}
        [HttpGet("client/{clientId}")]
        public ActionResult<IEnumerable<Address>> GetAddressesByClientId(int clientId)
        {
            var addresses = _addressService.GetAddressesByClientId(clientId);
            return Ok(addresses);
        }

        //POST: api/Address
        [HttpPost]
        public ActionResult AddAddress([FromBody] Address address)
        {
            if (address == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _addressService.AddAddress(address);
            return Ok(address);
        }


        //PUT: api/Address/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, [FromBody] Address address)
        {
            address.AddressId = id;
            _addressService.UpdateAddress(address);
            return Ok();
        }

        //DELETE: api/Address/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            _addressService.DeleteAddress(id);
            return Ok();
        }
    }
}
