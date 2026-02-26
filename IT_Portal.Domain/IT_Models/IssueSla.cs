using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class IssueSla
{
    public int IssueSlaid { get; set; }

    public int? IssueId { get; set; }

    public int? EscalationId { get; set; }

    public DateTime? EscalationDt { get; set; }

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
