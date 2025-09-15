namespace IT_Portal.Domain.IT_Models;

public partial class VwIssueListHistory
{
    public int IssueId { get; set; }

    public string? IssueCode { get; set; }

    public int Raisedbyid { get; set; }

    public string? IssueRaiseBy { get; set; }

    public DateTime? IssueDate { get; set; } = null!;

    public string IssueShotDesc { get; set; } = null!;

    public string IssueDesc { get; set; } = null!;

    public string? IssueRaisedFor { get; set; }

    public int? Issuerisedforid { get; set; }

    public string? IssueForGuest { get; set; }

    public string? GuestCompany { get; set; }

    public int? PlantId { get; set; }

    public int? AssetId { get; set; }

    public int? CategoryId { get; set; }

    public int? Priorityid { get; set; }

    public string? Source { get; set; }

    public string? Attachment { get; set; }

    public string? Status { get; set; }

    public string? Type { get; set; }

    public int? AssignedToid { get; set; }

    public string? AssignedTo { get; set; } = null!;

    public int? Assignedbyid { get; set; }

    public string? AssignedBy { get; set; } = null!;

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; } = null!;

    public int? ModifiedBy { get; set; } = null!;

    public DateTime? ModifiedDt { get; set; } = null!;

    public string? CategoryName { get; set; }

    public int? CategoryTypId { get; set; }

    public string? CategoryType { get; set; }

    public string? Plantname { get; set; }

    public string? PriorityName { get; set; }

    public string? Slastatus { get; set; }

    public DateTime? AssignedOn { get; set; } = null!;

    public string? ResolvedBy { get; set; }

    public DateTime? ResolvedOn { get; set; } = null!;

    public string? ResolveRemarks { get; set; }

    public string? ClosedBy { get; set; }

    public string? ClosedRemark { get; set; }

    public DateTime? ClosedDate { get; set; } = null!;
}
