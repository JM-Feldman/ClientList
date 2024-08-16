using ClientDataCapture_API.Data;
using ClientDataCapture_API.Models;

namespace ClientDataCapture_API.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        //Retrieve all clients
        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        //Add a new client
        public void AddClient(Client client)
        {
            _clientRepository.AddClient(client);
        }

        //Update an existing client
        public void UpdateClient(Client client)
        {
            _clientRepository.UpdateClient(client);
        }

        //Delete a client by ID
        public void DeleteClient(int clientId)
        {
            _clientRepository.DeleteClient(clientId);
        }
    }

}
