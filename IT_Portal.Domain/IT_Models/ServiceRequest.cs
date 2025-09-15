namespace IT_Portal.Domain.IT_Models;

public partial class ServiceRequest
{
    public int Srid { get; set; }

    public string? Srcode { get; set; }

    public int? SupportId { get; set; }

    public string? Srselectedfor { get; set; }

    public int? SrraisedBy { get; set; }

    public DateTime? Srdate { get; set; }

    public string? SrshotDesc { get; set; }

    public string? Srdesc { get; set; }

    public int? SrraiseFor { get; set; }

    public int? GuestEmployeeId { get; set; }

    public string? GuestName { get; set; }

    public string? GuestEmail { get; set; }

    public string? GuestContactNo { get; set; }

    public string? GuestReportingManagerEmployeeId { get; set; }

    public string? Type { get; set; }

    public string? GuestCompany { get; set; }

    public int? PlantId { get; set; }

    public int? AssetId { get; set; }

    public int? CategoryId { get; set; }

    public int? CategoryTypId { get; set; }

    public int? Priority { get; set; }

    public string? SrforGuest { get; set; }

    public string? Source { get; set; }

    public string? Attachment { get; set; }

    public string? Status { get; set; }

    public int? AssignedTo { get; set; }

    public int? AssignedBy { get; set; }

    public DateTime? AssignedOn { get; set; }

    public DateTime? ProposedResolutionOn { get; set; }

    public string? Remarks { get; set; }

    public string? Stage { get; set; }

    public bool? IsApproved { get; set; }

    public string? Approverstage { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDt { get; set; }

    public int? OnHoldReason { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
