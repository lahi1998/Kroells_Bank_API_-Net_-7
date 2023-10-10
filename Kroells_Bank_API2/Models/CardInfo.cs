namespace Kroells_Bank_API2.Models
{
    public class CardInfo
    {
        public string? Client_Name { get; set; }

        public string? Card_Nr { get; set; }

        public short Cvv { get; set; }

        public DateTime Expire_Date { get; set; }

        public int? Spending_Limit { get; set; }

        public int Balance { get; set; }
    }
}
