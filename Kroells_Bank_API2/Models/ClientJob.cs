using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class ClientJob
{
    public int ClientJobId { get; set; }

    public int ClientId { get; set; }

    public int JobId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;
}
