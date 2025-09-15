namespace IT_Portal.Domain.IT_Models;

public partial class DmactionItem
{
    public int Id { get; set; }

    public int? Stage4ImpactAssessmentId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? ActionDetails { get; set; }

    public string? ResponsibleEmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeEmailId { get; set; }

    public DateTime? Tcd { get; set; }

    public string? Comments { get; set; }

    public DateTime? CompletionDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? ReturnComments { get; set; }

    public string? Attachments { get; set; }
}
