namespace IT_Portal.Domain.IT_Models;

public partial class Emactivity
{
    public int Id { get; set; }

    public int? Stage7EmproposalId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? Particulars { get; set; }

    public string? ResponsibleEmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeEmailId { get; set; }

    public string? ReferenceDocumentNumber { get; set; }

    public string? DocumentTitle { get; set; }

    public string? SectionNumber { get; set; }

    public string? VerificationComments { get; set; }

    public string? SummaryOfGaps { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? ReturnComments { get; set; }

    public string? Attachments { get; set; }
}
