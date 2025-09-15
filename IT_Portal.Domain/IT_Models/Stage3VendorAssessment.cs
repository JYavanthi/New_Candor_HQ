namespace IT_Portal.Domain.IT_Models;

public partial class Stage3VendorAssessment
{
    public int Id { get; set; }

    public int? Stage1DiscrepancyRequestId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? SpocemployeeId { get; set; }

    public string? AssessmentBy { get; set; }

    public string? VendorReferenceNumber { get; set; }

    public string? VendorAssessmentDetails { get; set; }

    public DateTime? VendorAssessmentDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? VendorEmployeeId { get; set; }

    public string? Attachments { get; set; }
}
