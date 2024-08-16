using ClientDataCapture_API.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ClientDataCapture_API.Data
{
    public class ContactInfoRepository
    {
        private readonly string _connectionString;

        public ContactInfoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Retrieve all contact info by client ID
        public IEnumerable<ContactInfo> GetContactInfosByClientId(int clientId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "SELECT * FROM ContactInfos WHERE ClientId = @ClientId";
                return connection.Query<ContactInfo>(sql, new { ClientId = clientId }).ToList();
            }
        }

        //Add a new contact info
        public void AddContactInfo(ContactInfo contactInfo)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "INSERT INTO ContactInfos (ClientId, WorkNumber, CellNumber, WorkEmail) VALUES (@ClientId, @WorkNumber, @CellNumber, @WorkEmail)";
                connection.Execute(sql, contactInfo);
            }
        }

        //Update an existing contact info
        public void UpdateContactInfo(ContactInfo contactInfo)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "UPDATE ContactInfos SET WorkNumber = @WorkNumber, CellNumber = @CellNumber, WorkEmail = @WorkEmail WHERE " +
                    "ContactInfoId = @ContactInfoId";
                connection.Execute(sql, contactInfo);
            }
        }

        //Delete a contact info by ID
        public void DeleteContactInfo(int contactInfoId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                string sql = "DELETE FROM ContactInfos WHERE ContactInfoId = @ContactInfoId";
                connection.Execute(sql, new { ContactInfoId = contactInfoId });
            }
        }
    }
}
