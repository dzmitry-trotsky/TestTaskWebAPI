using System;
using System.Collections.Generic;

namespace Data.Entities;

public class NodeEntity: EntityBase
{
    public string? NodeCode { get; set; }

    public long? ThreadId { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<LocationEntity> Locations { get; set; } = new List<LocationEntity>();

    public virtual ThreadEntity? Thread { get; set; }
}
