using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class PmMaster
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? ProjectDesc { get; set; }

    public string? ProjectGroup { get; set; }

    public string? ProjectAccess { get; set; }

    public string? Deliverables { get; set; }

    public int? ProjectOwner { get; set; }

    public DateTime? StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public bool? IsStrict { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
