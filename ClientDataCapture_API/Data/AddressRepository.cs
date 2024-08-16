using ClientDataCapture_API.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ClientDataCapture_API.Data
{
    public class AddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Retrieve all addresses by client ID
        public IEnumerable<Address> GetAddressesByClientId(int clientId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "SELECT * FROM Addresses WHERE ClientId = @ClientId";
                return connection.Query<Address>(sql, new { ClientId = clientId }).ToList();
            }
        }

        //Add a new address
        public void AddAddress(Address address)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "INSERT INTO Addresses (ClientId, AddressType, AddressLine, City, State, PostalCode) " +
                    "VALUES (@ClientId, @AddressType, @AddressLine, @City, @State, @PostalCode)";
                connection.Execute(sql, address);
            }
        }

        //Update an existing address
        public void UpdateAddress(Address address)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "UPDATE Addresses SET AddressType = @AddressType, AddressLine = @AddressLine, " +
                     "City = @City, State = @State, PostalCode = @PostalCode WHERE AddressId = @AddressId";
                connection.Execute(sql, address);
            }
        }

        //Delete an address by ID
        public void DeleteAddress(int addressId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "DELETE FROM Addresses WHERE AddressId = @AddressId";
                connection.Execute(sql, new { AddressId = addressId });
            }
        }
    }
}
