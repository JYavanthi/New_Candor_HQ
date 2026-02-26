using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwChangeRequest
{
    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public int SupportId { get; set; }

    public bool? CrremailNotification { get; set; }

    public string? Crowner { get; set; }

    public int Crownerid { get; set; }

    public string? ChangeDesc { get; set; }

    public int ItcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ItclassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public DateTime Crdate { get; set; }

    public bool? IsSubmitted { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsReleased { get; set; }

    public string? SysLandscapeId { get; set; }

    public string? Stage { get; set; }

    public string? Status { get; set; }

    public decimal? EstimatedCost { get; set; }

    public string? EstimatedCostCurr { get; set; }

    public DateOnly? EstimatedDateCompletion { get; set; }

    public int? ApprovedBy { get; set; }

    public int? PriorityType { get; set; }

    public string PriorityName { get; set; } = null!;

    public int ChangeRequestor { get; set; }

    public string PlantId { get; set; } = null!;

    public int? Plantcode { get; set; }

    public string? NatureofChange { get; set; }

    public string? CategoryType { get; set; }

    public int? CategoryTypeId { get; set; }

    public int? CrinitiatedFor { get; set; }

    public string InitiatedFor { get; set; } = null!;

    public bool? IsImplemented { get; set; }

    public int? CrrequestedBy { get; set; }

    public string RequestorPlant { get; set; } = null!;

    public string CrrequestorName { get; set; } = null!;

    public string? Crremail { get; set; }

    public string? Attachment { get; set; }

    public int? ReferenceId { get; set; }

    public int? ReferenceTyp { get; set; }

    public string? TriggeredBy { get; set; }

    public string? AlternateConsidetation { get; set; }

    public string? BackoutPlan { get; set; }

    public string? Benefits { get; set; }

    public bool? Gxpclassification { get; set; }

    public int? GxpplantId { get; set; }

    public string? ImactedFunc { get; set; }

    public string? ImpactedDept { get; set; }

    public string? ImpactedLocation { get; set; }

    public string? ImpactNotDoing { get; set; }

    public string? BusinessImpact { get; set; }

    public DateTime? DownTimeFromDate { get; set; }

    public DateTime? DownTimeToDate { get; set; }

    public bool? DownTimeRequired { get; set; }

    public int? Taskcount { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? RollbackPlan { get; set; }
}
