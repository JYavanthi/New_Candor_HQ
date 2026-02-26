using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwServiceRequest
{
    public int Srid { get; set; }

    public string? Srcode { get; set; }

    public int? SupportId { get; set; }

    public string? SrraiseBy { get; set; }

    public int? SrraisedById { get; set; }

    public string? SrraisedByEmail { get; set; }

    public int? SrraiseForId { get; set; }

    public DateTime? Srdate { get; set; }

    public string? SrshotDesc { get; set; }

    public string? Srdesc { get; set; }

    public string? Srselectedfor { get; set; }

    public string? SrraiseFor { get; set; }

    public string? SrraisedForEmail { get; set; }

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

    public int? RaiseforId { get; set; }

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

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? RpmEmpNo { get; set; }

    public int? HodEmpNo { get; set; }

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

    public string GuestReportingManagerName { get; set; } = null!;

    public string? AssignToName { get; set; }

    public string? HodToName { get; set; }

    public string? HodEmail { get; set; }

    public string? RpmToName { get; set; }

    public string? RpmEmail { get; set; }

    public string? ParentSupportName { get; set; }

    public int? ServiceId { get; set; }

    public string? OnholdReason { get; set; }
}
