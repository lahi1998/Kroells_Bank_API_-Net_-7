using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Loan
{
    public int ClientAccountId { get; set; }

    public int ClientId { get; set; }

    public byte Apr { get; set; }

    public int Amount { get; set; }

    public virtual Client Client { get; set; } = null!;
}
