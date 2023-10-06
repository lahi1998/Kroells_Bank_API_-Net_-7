namespace Kroells_Bank_API2.Models
{
    public class TransferDTO
    {
        public int SenderID { get; set; }
        public int Amount { get; set; }
        public int ReciverCardNumber { get; set; }
    }
}
