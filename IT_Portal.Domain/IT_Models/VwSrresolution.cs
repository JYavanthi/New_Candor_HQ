using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwSrresolution
{
    public int SrresolId { get; set; }

    public int Srid { get; set; }

    public string? ResolRemarks { get; set; }

    public string? UserRemarks { get; set; }

    public DateTime? ProposedResolDt { get; set; }

    public DateTime? ResolDt { get; set; }

    public string? Description { get; set; }

    public string? OnHoldReason { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string CreatedByName { get; set; } = null!;
}
