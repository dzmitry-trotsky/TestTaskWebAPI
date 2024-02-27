using System;
using System.Collections.Generic;

namespace Data.Entities;

public class PassportParamEntity : EntityBase
{
    public string ParamName { get; set; } = null!;

    public long? UnitTypeId { get; set; }

    public virtual UnitTypeEntity? UnitType { get; set; }
}
