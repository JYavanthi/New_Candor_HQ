namespace IT_Portal.Domain.IT_Models;

public partial class VwChangeRequestSummary
{
    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public int SupportId { get; set; }

    public string? Crowner { get; set; }

    public string? ChangeDesc { get; set; }

    public int ItcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ItclassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public DateTime Crdate { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsReleased { get; set; }

    public string? Stage { get; set; }

    public string? Status { get; set; }

    public decimal? EstimatedCost { get; set; }

    public string? EstimatedCostCurr { get; set; }

    public DateOnly? EstimatedDateCompletion { get; set; }

    public int? ApprovedBy { get; set; }

    public int? PriorityType { get; set; }

    public int ChangeRequestor { get; set; }

    public string? PlantId { get; set; }

    public int? Plantcode { get; set; }

    public string? InitiatedFor { get; set; }

    public string? NatureofChange { get; set; }

    public string? CategoryType { get; set; }

    public string? ReasonForChange { get; set; }

    public string? AlternateConsidetation { get; set; }

    public string? BackoutPlan { get; set; }

    public string? BusinessImpact { get; set; }

    public string? Changerequestedby { get; set; }

    public string? ReferenceName { get; set; }

    public string? ReferenceType { get; set; }

    public string? ChangeControlNo { get; set; }

    public DateOnly? ChangeControlDt { get; set; }

    public string? Gxpplant { get; set; }

    public DateTime? DownTimeFromDate { get; set; }

    public DateTime? DownTimeToDate { get; set; }

    public string? ImactedFunc { get; set; }

    public string? ImpactedLocation { get; set; }

    public string? ImpactedDept { get; set; }

    public string? ImpactNotDoing { get; set; }

    public string? TriggeredBy { get; set; }

    public DateTime? CrrequestedDt { get; set; }

    public string? Benefits { get; set; }

    public string? RollbackPlan { get; set; }

    public int? EstimatedEffort { get; set; }

    public string? EstimatedEffortUnit { get; set; }
}
