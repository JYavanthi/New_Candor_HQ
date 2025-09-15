namespace IT_Portal.Domain.IT_Models;

public partial class Stage1DiscrepancyRequest
{
    public int Id { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? RequestStatus { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public int? NextRevision { get; set; }

    public string? ReportedUser { get; set; }

    public string? ReportedPlant { get; set; }

    public int SoftwareId { get; set; }

    public string? SoftwareVersion { get; set; }

    public string? EquipmentName { get; set; }

    public string? EquipmentId { get; set; }

    public string? RequestType { get; set; }

    public string? RequirementDetails { get; set; }

    public string? OtherDetails { get; set; }

    public string? Discrepancy { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? SiteQaapproverEmployeeId { get; set; }

    public string? SiteQaapproverComments { get; set; }

    public string? SiteQaapprovalStatus { get; set; }

    public DateTime? SiteQaapprovalDate { get; set; }

    public string? PendingWith { get; set; }

    public string? Attachments { get; set; }

    public string? SiteQareturnComments { get; set; }

    public string? SiteQaattachments { get; set; }

    public int? OriginPlant { get; set; }

    public int? MergedRequestId { get; set; }
}
