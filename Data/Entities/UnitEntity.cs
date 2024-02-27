using System;
using System.Collections.Generic;

namespace Data.Entities;

public class UnitEntity : EntityBase
{
    public long? IngotId { get; set; }

    public DateTime DateReg { get; set; }

    public long? UnitTypeId { get; set; }

    public virtual ICollection<LocationEntity> Locations { get; set; } = new List<LocationEntity>();

    public virtual UnitTypeEntity? UnitType { get; set; }

    public virtual ICollection<UnitsRelationEntity> UnitsRelationUnitIdChildNavigations { get; set; } = new List<UnitsRelationEntity>();

    public virtual ICollection<UnitsRelationEntity> UnitsRelationUnitIdParentNavigations { get; set; } = new List<UnitsRelationEntity>();
}
