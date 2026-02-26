using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwIssueList
{
    public int IssueId { get; set; }

    public string? IssueCode { get; set; }

    public int Raisedbyid { get; set; }

    public string Issuerisedby { get; set; } = null!;

    public DateTime IssueDate { get; set; }

    public string IssueShotDesc { get; set; } = null!;

    public string IssueDesc { get; set; } = null!;

    public int? Issuerisedforid { get; set; }

    public string Issuerisedfor { get; set; } = null!;

    public string? IssueForGuest { get; set; }

    public string? IssueSelectedfor { get; set; }

    public string? GuestCompany { get; set; }

    public int? GuestEmployeeId { get; set; }

    public string? GuestName { get; set; }

    public string? GuestContactNo { get; set; }

    public string? Type { get; set; }

    public string? GuestReportingManagerEmployeeId { get; set; }

    public string? GuestEmail { get; set; }

    public int? PlantId { get; set; }

    public string? Plantname { get; set; }

    public int? AssetId { get; set; }

    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int? CategoryTypId { get; set; }

    public string? CategoryType { get; set; }

    public int? Priorityid { get; set; }

    public string? PriorityName { get; set; }

    public string? Source { get; set; }

    public string? Attachment { get; set; }

    public string? Status { get; set; }

    public int? AssignedToid { get; set; }

    public string? AssignedTo { get; set; }

    public int? Assignedbyid { get; set; }

    public string AssignedBy { get; set; } = null!;

    public DateTime? AssignedOn { get; set; }

    public DateTime? ProposedResolutionOn { get; set; }

    public DateTime? ResolutionDt { get; set; }

    public string? ResolutionRemarks { get; set; }

    public string? Remarks { get; set; }

    public int? ReasonId { get; set; }

    public string? OnHoldReason { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? Slastatus { get; set; }

    public DateTime? AssignedDt { get; set; }

    public string? ResolvedBy { get; set; }

    public DateTime? ResolvedOn { get; set; }

    public string? ResolveRemarks { get; set; }

    public string? ClosedBy { get; set; }

    public string? ClosedRemark { get; set; }

    public DateTime? ClosedDate { get; set; }

    public int? SlaTime { get; set; }

    public string? Slaunit { get; set; }
}
