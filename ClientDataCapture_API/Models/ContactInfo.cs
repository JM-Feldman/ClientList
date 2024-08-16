namespace ClientDataCapture_API.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public int ClientId { get; set; }
        public int WorkNumber { get; set; }
        public int CellNumber { get; set; }
        public string WorkEmail { get; set; }
      
       // public Client Client { get; set; }
    }
}
