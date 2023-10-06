using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int Amount { get; set; }

    public DateTime DateTime { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
