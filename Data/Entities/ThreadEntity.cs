using System;
using System.Collections.Generic;

namespace Data.Entities;

public class ThreadEntity : EntityBase
{
    public string? ThreadName { get; set; }

    public long ThreadNum { get; set; }

    public virtual ICollection<NodeEntity> Nodes { get; set; } = new List<NodeEntity>();
}
