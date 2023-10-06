using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int ZipCode { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int HouseNr { get; set; }

    public virtual ICollection<Cpr> Cprs { get; set; } = new List<Cpr>();
}
