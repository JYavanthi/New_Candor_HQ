namespace IT_Portal.Domain.IT_Models;

public partial class VwSrdomain
{
    public int SrdomainId { get; set; }

    public int? Support { get; set; }

    public int? Srid { get; set; }

    public string? DomainName { get; set; }

    public string? Plant { get; set; }

    public string? Department { get; set; }

    public int? NoofUser { get; set; }

    public string? PurPoseDomain { get; set; }

    public DateTime? DueDate { get; set; }

    public string? TypeofSsl { get; set; }

    public int? RenewalPeriod { get; set; }

    public string? Justification { get; set; }

    public DateTime? DiscontinuationDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ReqDomainName { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int SridServiceRequest { get; set; }

    public string GuestReportingManagerName { get; set; } = null!;

    public string? Srcode { get; set; }

    public int? SupportId { get; set; }

    public string? SrraiseBy { get; set; }

    public DateTime? Srdate { get; set; }

    public string? SrshotDesc { get; set; }

    public string? Srdesc { get; set; }

    public string? SrraiseFor { get; set; }

    public int? GuestEmployeeId { get; set; }

    public string? GuestName { get; set; }

    public string? GuestEmail { get; set; }

    public string? Srselectedfor { get; set; }

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

    public string? SrCreatedBy { get; set; }

    public DateTime? SrCreatedDt { get; set; }

    public string? SrModifiedBy { get; set; }

    public DateTime? SrModifiedDt { get; set; }

    public string? RpmEmail { get; set; }

    public string? HodEmail { get; set; }

    public string? HodToName { get; set; }

    public string? RpmToName { get; set; }

    public bool? IsHodreq { get; set; }

    public bool? IsRpmreq { get; set; }

    public string? RpmEmpNo { get; set; }

    public string? HodEmpNo { get; set; }
}
