namespace IT_Portal.Domain.IT_Models;

public partial class VwRptcrmilestone
{
    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public int SupportId { get; set; }

    public DateTime? DraftDt { get; set; }

    public DateTime? SubmittedDt { get; set; }

    public string Rfcapp1name { get; set; } = null!;

    public int Rfcapp1 { get; set; }

    public DateTime? RfcapproverLevel1Dt { get; set; }

    public string Rfcapp2name { get; set; } = null!;

    public int Rfcapp2 { get; set; }

    public DateTime? RfcapproverLevel2Dt { get; set; }

    public string Rfcappname { get; set; } = null!;

    public int Rfcappved { get; set; }

    public DateTime? RfcapprovedDt { get; set; }

    public DateTime? ImplementedDt { get; set; }

    public string Relapp1name { get; set; } = null!;

    public int Relapp1 { get; set; }

    public DateTime? RelApproverLevel1Dt { get; set; }

    public string Relapp2name { get; set; } = null!;

    public int Relapp2 { get; set; }

    public DateTime? RelApproverLevel2Dt { get; set; }

    public string Relappname { get; set; } = null!;

    public int Relappved { get; set; }

    public DateTime? RelApprovedDt { get; set; }

    public int? ReleasedBy { get; set; }

    public DateTime? ReleasedDt { get; set; }

    public string Colapp1name { get; set; } = null!;

    public int Colapp1 { get; set; }

    public DateTime? ColApproverLevel1Dt { get; set; }

    public string Colapp2name { get; set; } = null!;

    public int Colapp2 { get; set; }

    public DateTime? ColApproverLevel2Dt { get; set; }

    public string Colappname { get; set; } = null!;

    public int Colappved { get; set; }

    public DateTime? ColApprovedDt { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string Crowner { get; set; } = null!;

    public int Crownerid { get; set; }

    public string? ChangeDesc { get; set; }

    public int ItcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ItclassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public DateTime Crdate { get; set; }

    public string? Status { get; set; }
    public string? Stage { get; set; }
    public string? NatureofChange { get; set; }

    public decimal? EstimatedCost { get; set; }

    public string? EstimatedCostCurr { get; set; }

    public DateOnly? EstimatedDateCompletion { get; set; }

    public int? ApprovedBy { get; set; }

    public int? PriorityType { get; set; }

    public string PriorityName { get; set; } = null!;

    public int ChangeRequestor { get; set; }

    public string? PlantId { get; set; }

    public int? Plantcode { get; set; }

    public string? CategoryType { get; set; }

    public int? CategoryTypeId { get; set; }

    public int? CrinitiatedFor { get; set; }

    public string InitiatedFor { get; set; } = null!;

    public bool? IsImplemented { get; set; }

    public int? CrrequestedBy { get; set; }

    public string CrrequestorName { get; set; } = null!;
}
