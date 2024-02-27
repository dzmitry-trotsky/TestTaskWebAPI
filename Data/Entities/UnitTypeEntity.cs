using System;
using System.Collections.Generic;

namespace Data.Entities;

public class UnitTypeEntity : EntityBase
{
    public string TypeName { get; set; } = null!;

    public virtual ICollection<PassportParamEntity> PassportParams { get; set; } = new List<PassportParamEntity>();

    public virtual ICollection<UnitEntity> Units { get; set; } = new List<UnitEntity>();
}
