using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class ProjectMembersHistory
{
    public int PreMemHistoryId { get; set; }

    public int? PrMemberId { get; set; }

    public int? ProjectMgmtId { get; set; }

    public int? EmpId { get; set; }

    public string? Role { get; set; }

    public string? Type { get; set; }

    public bool? Responsible { get; set; }

    public bool? Accountable { get; set; }

    public bool? Consulted { get; set; }

    public bool? Informed { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
