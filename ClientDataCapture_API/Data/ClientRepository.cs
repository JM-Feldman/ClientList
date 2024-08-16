using ClientDataCapture_API.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ClientDataCapture_API.Data
{
    public class ClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Retrieve all clients
        public IEnumerable<Client> GetAllClients()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
             
                var clients = connection.Query<Client>("SELECT * FROM Clients").ToList();

         
                var addresses = connection.Query<Address>("SELECT * FROM Addresses").ToList();
                var contactInfos = connection.Query<ContactInfo>("SELECT * FROM ContactInfos").ToList();

                foreach (var client in clients)
                {
                    client.Addresses = addresses.Where(a => a.ClientId == client.ClientId).ToList();
                    client.ContactInfos = contactInfos.Where(c => c.ClientId == client.ClientId).ToList();
                }

                return clients;
            }
        }

        //Add a new client
        public void AddClient(Client client)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "INSERT INTO Clients (Name, Gender, BasicDetails) VALUES (@Name, @Gender, @BasicDetails)";
                connection.Execute(sql, client);
            }
        }

        //Update an existing client
        public void UpdateClient(Client client)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "UPDATE Clients SET Name = @Name, Gender = @Gender, BasicDetails = @BasicDetails WHERE ClientId = @ClientId";
                connection.Execute(sql, client);
            }
        }

        //Delete a client by ID
        public void DeleteClient(int clientId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "DELETE FROM Clients WHERE ClientId = @ClientId";
                connection.Execute(sql, new { ClientId = clientId });
            }
        }
    }
}
