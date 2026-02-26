using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwItspareDetail
{
    public string? ItspareCode { get; set; }

    public int ItspareId { get; set; }

    public string? Requesttype { get; set; }

    public int? RequestedBy { get; set; }

    public string RequestedByName { get; set; } = null!;

    public int? RequestedFor { get; set; }

    public string RequestedForName { get; set; } = null!;

    public string? Srselectedfor { get; set; }

    public int? GuestId { get; set; }

    public string? GuestName { get; set; }

    public string? GuestEmail { get; set; }

    public int? GuestReportingManagerEmployeeId { get; set; }

    public string GuestReportingManagerName { get; set; } = null!;

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

    public string? Status { get; set; }

    public int? AssignedTo { get; set; }

    public string AssignedToName { get; set; } = null!;

    public int? AssignedBy { get; set; }

    public string AssignedByName { get; set; } = null!;

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

    public string? SupportName { get; set; }

    public bool? IsHodreq { get; set; }

    public bool? IsRpmreq { get; set; }

    public int? SupportId { get; set; }

    public string? EmployeeNo { get; set; }

    public int? RpmEmpNo { get; set; }

    public int? HodEmpNo { get; set; }

    public string? OnholdReason { get; set; }

    public string? HodToName { get; set; }

    public string? HodEmail { get; set; }

    public string? RpmToName { get; set; }

    public string? RpmEmail { get; set; }

    public bool? IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime? ModifiedDt { get; set; }
}
