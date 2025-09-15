namespace IT_Portal.Domain.IT_Models;

public partial class Stage2Spocassessment
{
    public int Id { get; set; }

    public int? Stage1DiscrepancyRequestId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? SpocemployeeId { get; set; }

    public string? VerificationofEvs { get; set; }

    public string? Impact { get; set; }

    public string? ActionTaken { get; set; }

    public string? IssueIntimatedToOtherSites { get; set; }

    public string? SiteCodes { get; set; }

    public string? IsRepeatIssue { get; set; }

    public string? PreviousReferenceNumber { get; set; }

    public string? PreviousActionsSummary { get; set; }

    public DateTime? SpocapprovalDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? ReturnComments { get; set; }

    public string? Attachments { get; set; }

    public string? DropComments { get; set; }
}
