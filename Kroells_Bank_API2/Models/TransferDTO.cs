namespace Kroells_Bank_API2.Models
{
    public class TransferDTO
    {
        public int SenderID { get; set; }
        public decimal Amount { get; set; }
        public string ReciverCardNumber { get; set; } = string.Empty;
    }
}
