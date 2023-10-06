using System;
using System.Collections.Generic;

namespace Kroells_Bank_API2.Models;

public partial class Job
{
    public int JobId { get; set; }

    public int Income { get; set; }

    public string JobName { get; set; } = null!;

    public virtual ICollection<ClientJob> ClientJobs { get; set; } = new List<ClientJob>();
}
