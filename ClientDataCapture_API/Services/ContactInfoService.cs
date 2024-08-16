using ClientDataCapture_API.Data;
using ClientDataCapture_API.Models;

namespace ClientDataCapture_API.Services
{
    public class ContactInfoService
    {
        private readonly ContactInfoRepository _contactInfoRepository;

        public ContactInfoService(ContactInfoRepository contactInfoRepository)
        {
            _contactInfoRepository = contactInfoRepository;
        }

        //Retrieve all contact info by client ID
        public IEnumerable<ContactInfo> GetContactInfosByClientId(int clientId)
        {
            return _contactInfoRepository.GetContactInfosByClientId(clientId);
        }

        //Add a new contact info
        public void AddContactInfo(ContactInfo contactInfo)
        {
            _contactInfoRepository.AddContactInfo(contactInfo);
        }

        //Update an existing contact info
        public void UpdateContactInfo(ContactInfo contactInfo)
        {
            _contactInfoRepository.UpdateContactInfo(contactInfo);
        }

        //Delete a contact info by ID
        public void DeleteContactInfo(int contactInfoId)
        {
            _contactInfoRepository.DeleteContactInfo(contactInfoId);
        }
    }

}
