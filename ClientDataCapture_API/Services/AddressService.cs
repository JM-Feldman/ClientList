using ClientDataCapture_API.Data;
using ClientDataCapture_API.Models;

namespace ClientDataCapture_API.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        //Retrieve all addresses by client ID
        public IEnumerable<Address> GetAddressesByClientId(int clientId)
        {
            return _addressRepository.GetAddressesByClientId(clientId);
        }

        //Add a new address
        public void AddAddress(Address address)
        {
            _addressRepository.AddAddress(address);
        }

        //Update an existing address
        public void UpdateAddress(Address address)
        {
            _addressRepository.UpdateAddress(address);
        }

        //Delete an address by ID
        public void DeleteAddress(int addressId)
        {
            _addressRepository.DeleteAddress(addressId);
        }
    }

}
