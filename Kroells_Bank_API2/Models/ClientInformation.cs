namespace Kroells_Bank_API.Models
{
    public class ClientInformation
    {
        public int Client_Id { get; set; }
        public string Client_Name { get; set; } = string.Empty;
        public int Income { get; set; }
        public string Job_Name { get; set; } = string.Empty;
        public int Zip_Code { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int House_Nr { get; set; }
    }

}
