using System;
using System.Collections.Generic;

namespace Data.Entities;

public class LocationEntity : EntityBase
{
    public long NodeId { get; set; }

    public DateTime TmBeg { get; set; }

    public DateTime? TmEnd { get; set; }

    public long UnitId { get; set; }

    public virtual NodeEntity Node { get; set; } = null!;

    public virtual UnitEntity Unit { get; set; } = null!;
}
