using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string? Username { get; set; }

    public string? PasswordHashed { get; set; }

    public virtual ICollection<ClientAccount> ClientAccounts { get; set; } = new List<ClientAccount>();

    public virtual ICollection<ClientJob> ClientJobs { get; set; } = new List<ClientJob>();

    public virtual ICollection<Cpr> Cprs { get; set; } = new List<Cpr>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
