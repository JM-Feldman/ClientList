namespace ClientDataCapture_API.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public string AddressType { get; set; }
        public string AddressLine { get; set; }  
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        //public Client Client { get; set; }
    }
}
