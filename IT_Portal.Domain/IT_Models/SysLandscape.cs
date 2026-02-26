using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SysLandscape
{
    public int SysLandscapeId { get; set; }

    public int SupportId { get; set; }

    public int CategoryId { get; set; }

    public int ClassificationId { get; set; }

    public string SysLandscape1 { get; set; } = null!;

    public int? PriorityNum { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Classification Classification { get; set; } = null!;
}
