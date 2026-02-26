using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwProjectMgmt
{
    public int ProjectMgmtId { get; set; }

    public int SupportId { get; set; }

    public string ProjectCode { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string? ProjectDesc { get; set; }

    public int? ProjectOwner { get; set; }

    public DateTime? StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public DateTime? ActualStartDt { get; set; }

    public DateTime? ActualEndDt { get; set; }

    public bool? IsActive { get; set; }

    public int? EstimateHrs { get; set; }

    public decimal? EstimateCost { get; set; }

    public int? ActualHrs { get; set; }

    public decimal? ActualCost { get; set; }

    public string? Approver1Remark { get; set; }

    public string? Approver2Remark { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? PlantId { get; set; }

    public int? Sponser { get; set; }

    public int? ProjectGroupId { get; set; }

    public string? ProjectAccess { get; set; }

    public string? Deliverables { get; set; }

    public string? AdditionalNotes { get; set; }

    public string? ProjectGroupName { get; set; }

    public int? Approver1 { get; set; }

    public int? Approver2 { get; set; }

    public string? Status { get; set; }

    public int? ProjectDurationDays { get; set; }

    public string? ProjectStatus { get; set; }

    public string ProjectOwnerName { get; set; } = null!;

    public string SponserName { get; set; } = null!;

    public string CreatedByName { get; set; } = null!;

    public int? NumberOfPendingMilestones { get; set; }

    public int? NumberOfCompletedMilestones { get; set; }

    public int? NumberOfPendingTask { get; set; }

    public int? NumberOfCompletedTask { get; set; }

    public int? NumberOfTask { get; set; }
}
