using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class IssueList
{
    public int IssueId { get; set; }

    public string? IssueCode { get; set; }

    public string? IssueSelectedfor { get; set; }

    public int IssueRaisedBy { get; set; }

    public DateTime IssueDate { get; set; }

    public string IssueShotDesc { get; set; } = null!;

    public string IssueDesc { get; set; } = null!;

    public int? IssueRaiseFor { get; set; }

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

    public string? IssueForGuest { get; set; }

    public string? Source { get; set; }

    public string? Attachment { get; set; }

    public string? Status { get; set; }

    public int? AssignedTo { get; set; }

    public int? AssignedBy { get; set; }

    public DateTime? AssignedOn { get; set; }

    public DateTime? ProposedResolutionOn { get; set; }

    public string? Remarks { get; set; }

    public DateTime? ResolutionDt { get; set; }

    public string? ResolutionRemarks { get; set; }

    public int? ReasonId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
