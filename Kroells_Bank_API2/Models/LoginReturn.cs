namespace Kroells_Bank_API2.Models
{
    public class LoginReturn
    {
        public int Account_Id { get; set; }
        public int Client_Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHashed { get; set; } = string.Empty;
    }
}
