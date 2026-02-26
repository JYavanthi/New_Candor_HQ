using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwCrrelease
{
    public int CrreleaseId { get; set; }

    public int Itcrid { get; set; }

    public int SysLandscape { get; set; }

    public string ReleaseComments { get; set; } = null!;

    public int? AssignedTo { get; set; }

    public DateTime? ReleaseDt { get; set; }

    public string? Attachments { get; set; }

    public string? Status { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
