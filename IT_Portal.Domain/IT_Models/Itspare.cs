namespace IT_Portal.Domain.IT_Models;

public partial class Itspare
{
    public int ItspareId { get; set; }

    public string? ItspareCode { get; set; }

    public int? SupportId { get; set; }

    public string? Requesttype { get; set; }

    public int? RequestedBy { get; set; }

    public int? RequestedFor { get; set; }

    public string? SelectedFor { get; set; }

    public int? GuestId { get; set; }

    public string? GuestName { get; set; }

    public string? GuestEmail { get; set; }

    public int? GuestRmanagerId { get; set; }

    public int? GuestContactNo { get; set; }

    public string? EmpType { get; set; }

    public int? EmpId { get; set; }

    public string? GxpReq { get; set; }

    public string? AssetType { get; set; }

    public string? SpareType { get; set; }

    public string? SpareModel { get; set; }

    public string? SpareSerialNo { get; set; }

    public string? SpecsRequirements { get; set; }

    public string? Specification { get; set; }

    public string? Justification { get; set; }

    public string? HodApproval { get; set; }

    public bool? IsActive { get; set; }

    public int? HodApproverId { get; set; }

    public DateTime? HodApprovedDt { get; set; }

    public string? HodApproverRemarks { get; set; }

    public int? RpmApproverId { get; set; }

    public DateTime? RpmApprovedDt { get; set; }

    public string? RpmApproverRemarks { get; set; }

    public string? ResolRemarks { get; set; }

    public string? UserRemarks { get; set; }

    public DateTime? ProposedResolDt { get; set; }

    public DateTime? ResolDt { get; set; }

    public string? Description { get; set; }

    public int? OnHoldReason { get; set; }

    public string? Status { get; set; }

    public int? AssignedBy { get; set; }

    public int? AssignedTo { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
