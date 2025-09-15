namespace IT_Portal.Domain.IT_Models;

public partial class Stage4ImpactAssessment
{
    public int Id { get; set; }

    public int? Stage1DiscrepancyRequestId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? SpocemployeeId { get; set; }

    public string? RootCauseDetails { get; set; }

    public string? DiscrepancyCategory { get; set; }

    public string? OtherIssueDetails { get; set; }

    public string? ImpactAssessment { get; set; }

    public string? IssueImpactOn { get; set; }

    public string? DeviationReferenceNumber { get; set; }

    public string? IsChangeControlRequired { get; set; }

    public string? ChangeControlReferenceNumber { get; set; }

    public string? IsFurtherValidationRequired { get; set; }

    public string? Environments { get; set; }

    public string? Justification { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? ReturnComments { get; set; }

    public string? Attachments { get; set; }
}
