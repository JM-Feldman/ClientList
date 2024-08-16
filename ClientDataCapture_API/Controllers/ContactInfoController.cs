using ClientDataCapture_API.Models;
using ClientDataCapture_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientDataCapture_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly ContactInfoService _contactInfoService;

        public ContactInfoController(ContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        //GET: api/ContactInfo/client/{clientId}
        [HttpGet("client/{clientId}")]
        public ActionResult<IEnumerable<ContactInfo>> GetContactInfosByClientId(int clientId)
        {
            var contactInfos = _contactInfoService.GetContactInfosByClientId(clientId);
            return Ok(contactInfos);
        }

        //POST: api/ContactInfo
        [HttpPost]
        public ActionResult AddContactInfo([FromBody] ContactInfo contactInfo)
        {
            _contactInfoService.AddContactInfo(contactInfo);
            return Ok(contactInfo);
        }

        //PUT: api/ContactInfo/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateContactInfo(int id, [FromBody] ContactInfo contactInfo)
        {
            contactInfo.ContactInfoId = id;
            _contactInfoService.UpdateContactInfo(contactInfo);
            return Ok();
        }

        //DELETE: api/ContactInfo/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContactInfo(int id)
        {
            _contactInfoService.DeleteContactInfo(id);
            return Ok();
        }
    }
}
