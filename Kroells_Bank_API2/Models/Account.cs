using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public int Balance { get; set; }

    public int CardId { get; set; }

    public virtual Card Card { get; set; } = null!;

    public virtual ICollection<ClientAccount> ClientAccounts { get; set; } = new List<ClientAccount>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
