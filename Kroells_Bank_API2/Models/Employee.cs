using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Position { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHashed { get; set; } = null!;

    public virtual ICollection<Cpr> Cprs { get; set; } = new List<Cpr>();
}
