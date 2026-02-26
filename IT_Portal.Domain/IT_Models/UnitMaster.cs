using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class UnitMaster
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int? LocId { get; set; }

    public string Name { get; set; } = null!;

    public string ToMail { get; set; } = null!;

    public string OutwardMail { get; set; } = null!;

    public string VisitorMail { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int PlantType { get; set; }

    public string? PrintName { get; set; }

    public string? LocHead { get; set; }

    public string? LocGroup { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
