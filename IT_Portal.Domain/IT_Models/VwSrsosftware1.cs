namespace IT_Portal.Domain.IT_Models;

public partial class VwSrsosftware1
{
    public int Swid { get; set; }

    public int? Srid { get; set; }

    public string? SoftwareType { get; set; }

    public int? SoftwareName { get; set; }

    public int? SoftwareVersionName { get; set; }

    public string? VendorName { get; set; }

    public string? InstType { get; set; }

    public string? LicenceType { get; set; }

    public string? Location { get; set; }

    public string? Department { get; set; }

    public int? NoOfUers { get; set; }

    public int? NoOfLicence { get; set; }

    public decimal? CostPerLicence { get; set; }

    public decimal? TotalCost { get; set; }

    public bool? Amcappilcable { get; set; }

    public decimal? CostForAmc { get; set; }

    public string? ScopeOfAmc { get; set; }

    public bool? IsInstReq { get; set; }

    public decimal? InstCharge { get; set; }

    public string? DtlsOfInst { get; set; }

    public DateTime? DtlsOfinstDt { get; set; }

    public string? TypeOfDev { get; set; }

    public string? DtlsOfDev { get; set; }

    public bool? IsInterfaceReq { get; set; }

    public string? InterfaceReq { get; set; }

    public string? InterfaceWith { get; set; }

    public bool? IsGxpApp { get; set; }

    public string? NonFunReq { get; set; }

    public string? DtlsOfReq { get; set; }

    public string? WhereHosted { get; set; }

    public string? TypeOfWeb { get; set; }

    public string? UsageBy { get; set; }

    public string? UserAccessFrom { get; set; }

    public string? CurrVersion { get; set; }

    public string? TareVersion { get; set; }

    public string? Brds { get; set; }

    public string? BusJustification { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? Justification { get; set; }

    public int? NoofUseruse { get; set; }

    public string? Srcode { get; set; }

    public int? SupportId { get; set; }

    public string? SrraiseBy { get; set; }

    public DateTime? Srdate { get; set; }

    public string? SrshotDesc { get; set; }

    public string? Srdesc { get; set; }

    public string? SrraiseFor { get; set; }

    public string? Srselectedfor { get; set; }

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

    public string? RpmEmail { get; set; }

    public string? HodEmail { get; set; }

    public string? HodToName { get; set; }

    public string? HodEmpNo { get; set; }

    public string? RpmEmpNo { get; set; }

    public string? RpmToName { get; set; }

    public int? RaiseforId { get; set; }

    public int? SrraisedById { get; set; }

    public string? SrraisedByEmail { get; set; }

    public string? SrraisedForEmail { get; set; }

    public string GuestReportingManagerName { get; set; } = null!;

    public string? SupportName { get; set; }

    public int? ParentId { get; set; }

    public bool? SupportIsActive { get; set; }

    public bool? IsVisible { get; set; }

    public string? Image { get; set; }

    public string? Url { get; set; }

    public bool? IsHodreq { get; set; }

    public bool? IsRpmreq { get; set; }

    public int? SupportCreatedBy { get; set; }

    public DateTime? SupportCreatedDate { get; set; }

    public int? SupportUpdatedBy { get; set; }

    public DateTime? SupportUpdatedDate { get; set; }

    public string? ParentSupportName { get; set; }
}
