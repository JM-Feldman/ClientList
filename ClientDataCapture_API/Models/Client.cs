using System.Net;

namespace ClientDataCapture_API.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BasicDetails { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
    }
}
