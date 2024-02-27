using System;
using System.Collections.Generic;

namespace Data.Entities;

public class UnitsRelationEntity : EntityBase
{
    public DateTime DateReg { get; set; }

    public long UnitIdParent { get; set; }

    public long UnitIdChild { get; set; }

    public virtual UnitEntity UnitIdChildNavigation { get; set; } = null!;

    public virtual UnitEntity UnitIdParentNavigation { get; set; } = null!;
}
