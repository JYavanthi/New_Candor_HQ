using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwApproverView
{
    public string Crcode { get; set; } = null!;

    public int Itcrid { get; set; }

    public string? ChangeDesc { get; set; }

    public int ItcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ItclassificationId { get; set; }

    public int? Plantcode { get; set; }

    public string? ClassificationName { get; set; }

    public DateTime Crdate { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public bool? IsImplemented { get; set; }

    public bool? IsSubmitted { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsReleased { get; set; }

    public string? Stage { get; set; }

    public string? Status { get; set; }

    public decimal? EstimatedCost { get; set; }

    public string? EstimatedCostCurr { get; set; }

    public DateOnly? EstimatedDateCompletion { get; set; }

    public int? ApprovedBy { get; set; }

    public int? PriorityType { get; set; }

    public string PlantId { get; set; } = null!;

    public int? ChangeRequestor { get; set; }

    public string CrrequestorName { get; set; } = null!;

    public int? Taskcount { get; set; }

    public int? LastApprovedId { get; set; }

    public string? LastApproverName { get; set; }

    public DateTime? LastApprovedDate { get; set; }

    public int? Approver1 { get; set; }

    public int? Approver2 { get; set; }

    public int? Approver3 { get; set; }
}
