using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Cpr
{
    public int CprId { get; set; }

    public int ClientId { get; set; }

    public int AddressId { get; set; }

    public int EmployeeId { get; set; }

    public int CprNr { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
