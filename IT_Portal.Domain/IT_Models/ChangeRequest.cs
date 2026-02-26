using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class ChangeRequest
{
    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public int SupportId { get; set; }

    public int ClassificationId { get; set; }

    public int CategoryId { get; set; }

    public int Crowner { get; set; }

    public DateTime Crdate { get; set; }

    public int? CrrequestedBy { get; set; }

    public DateTime? CrrequestedDt { get; set; }

    public int? CrinitiatedFor { get; set; }

    public bool? CrremailNotification { get; set; }

    public string? Stage { get; set; }

    public string? Status { get; set; }

    public int? ReferenceId { get; set; }

    public int? ReferenceTyp { get; set; }

    public int? CategoryTypeId { get; set; }

    public int? NatureOfChange { get; set; }

    public int? PriorityType { get; set; }

    public int? PlantId { get; set; }

    public string? SysLandscapeId { get; set; }

    public bool? Gxpclassification { get; set; }

    public int? GxpplantId { get; set; }

    public string? ChangeControlNo { get; set; }

    public DateOnly? ChangeControlDt { get; set; }

    public bool? ChangeControlAttach { get; set; }

    public string? ChangeDesc { get; set; }

    public string? ReasonForChange { get; set; }

    public string? AlternateConsidetation { get; set; }

    public string? ImpactNotDoing { get; set; }

    public string? BusinessImpact { get; set; }

    public string? TriggeredBy { get; set; }

    public string? Benefits { get; set; }

    public decimal? EstimatedCost { get; set; }

    public string? EstimatedCostCurr { get; set; }

    public int? EstimatedEffort { get; set; }

    public string? EstimatedEffortUnit { get; set; }

    public DateOnly? EstimatedDateCompletion { get; set; }

    public string? RollbackPlan { get; set; }

    public string? BackoutPlan { get; set; }

    public bool? DownTimeRequired { get; set; }

    public DateTime? DownTimeFromDate { get; set; }

    public DateTime? DownTimeToDate { get; set; }

    public string? ImpactedLocation { get; set; }

    public string? ImpactedDept { get; set; }

    public string? ImactedFunc { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedDt { get; set; }

    public bool? IsSubmitted { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsImplemented { get; set; }

    public bool? IsReleased { get; set; }

    public string? ClosedStatus { get; set; }

    public string? ClosureRemarks { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedDt { get; set; }

    public string? Feedback { get; set; }

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? Attachment { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Classification Classification { get; set; } = null!;

    public virtual ICollection<CrexecutionPlan> CrexecutionPlans { get; set; } = new List<CrexecutionPlan>();

    public virtual ICollection<Crfollowup> Crfollowups { get; set; } = new List<Crfollowup>();

    public virtual ICollection<Crlesson> Crlessons { get; set; } = new List<Crlesson>();

    public virtual ICollection<Crmilestone> Crmilestones { get; set; } = new List<Crmilestone>();

    public virtual ICollection<Crrelease> Crreleases { get; set; } = new List<Crrelease>();
}
