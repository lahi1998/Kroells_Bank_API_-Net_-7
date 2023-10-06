using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class ClientAccount
{
    public int ClientAccountId { get; set; }

    public int ClientId { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}
