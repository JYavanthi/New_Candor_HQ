using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwSrcommonHistory
{
    public int? Srid { get; set; }

    public string? Srcode { get; set; }

    public string? SupportName { get; set; }

    public string? Remarks { get; set; }

    public string? Justification { get; set; }

    public string? Status { get; set; }

    public bool? IsActive { get; set; }

    public string CreatedByName { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string ModifiedByName { get; set; } = null!;

    public DateTime? ModifiedDt { get; set; }

    public int? SrresolHistoryId { get; set; }

    public string? ResolRemarks { get; set; }

    public string? UserRemarks { get; set; }

    public string? ApprRemarks { get; set; }
}
