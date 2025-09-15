namespace IT_Portal.Domain.IT_Models;

public partial class ProposedAction
{
    public int Id { get; set; }

    public int? EmactivityId { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? StageStatus { get; set; }

    public int? Revision { get; set; }

    public string? Action { get; set; }

    public string? DepartmentResponsible { get; set; }

    public DateTime? Tcd { get; set; }

    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? Attachments { get; set; }
}
