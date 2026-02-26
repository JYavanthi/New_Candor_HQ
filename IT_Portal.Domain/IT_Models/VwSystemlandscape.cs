using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwSystemlandscape
{
    public int SysLandscapeId { get; set; }

    public int SupportId { get; set; }

    public int CategoryId { get; set; }

    public int ClassificationId { get; set; }

    public string? CategoryName { get; set; }

    public string? ClassificationName { get; set; }

    public string SysLandscape { get; set; } = null!;

    public int? PriorityNum { get; set; }

    public string? PriorityName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
