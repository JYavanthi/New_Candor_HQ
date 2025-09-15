namespace IT_Portal.Domain.IT_Models;

public partial class ProjectIssueHistory
{
    public int IssueHistoryId { get; set; }

    public int? IssueId { get; set; }

    public string? IssueCode { get; set; }

    public int? TaskId { get; set; }

    public int? ProjectMgmtId { get; set; }

    public int? SubTaskId { get; set; }

    public int? MileStoneId { get; set; }

    public string? ProjectLevel { get; set; }

    public string? Description { get; set; }

    public string? Priority { get; set; }

    public string? Impact { get; set; }

    public DateTime? DateOpened { get; set; }

    public DateTime? DateClosed { get; set; }

    public int? IssueOwner { get; set; }

    public string? Department { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public int? AssignedTo { get; set; }

    public int? AssignedBy { get; set; }

    public DateTime? AssignedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
