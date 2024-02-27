using System;
using System.Collections.Generic;

namespace Data.Entities;

public partial class PassportEntity : EntityBase
{
    public long UnitId { get; set; }

    public long ParamId { get; set; }

    public DateTime ParamDate { get; set; }

    public double? ValueN { get; set; }

    public string? ValueS { get; set; }

    public string? ValueD { get; set; }

    public string? ValueJ { get; set; }
    public virtual PassportParamEntity Param { get; set; } = null!;

    public virtual UnitEntity Unit { get; set; } = null!;
}
