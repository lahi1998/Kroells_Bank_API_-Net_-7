using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Card
{
    public int CardId { get; set; }

    public int CardNr { get; set; }

    public DateTime ExpireDate { get; set; }

    public short Cvv { get; set; }

    public string ClientName { get; set; } = null!;

    public short Pin { get; set; }

    public int? SpendingLimit { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
