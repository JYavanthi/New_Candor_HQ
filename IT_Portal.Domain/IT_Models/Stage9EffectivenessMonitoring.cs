namespace IT_Portal.Domain.IT_Models;

public partial class Stage9EffectivenessMonitoring
{
    public int Id { get; set; }

    public int? Stage1DiscrepancyRequestId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? SpocemployeeId { get; set; }

    public string? Comments { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? ReturnComments { get; set; }

    public string? Attachments { get; set; }
}
