namespace IT_Portal.Domain.IT_Models;

public partial class ProjectMilestoneHistory
{
    public int ProjMileHistoryId { get; set; }

    public int? ProjMilestoneId { get; set; }

    public int ProjectId { get; set; }

    public string? MilestoneTitle { get; set; }

    public string? MilestoneDesc { get; set; }

    public string? MilestoneStatus { get; set; }

    public string? Owner { get; set; }

    public string? Priority { get; set; }

    public string? Status { get; set; }

    public DateTime? StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public DateTime? ActualStartDt { get; set; }

    public DateTime? ActualEndDt { get; set; }

    public DateTime? FinishStartDt { get; set; }

    public DateTime? FinishEndDt { get; set; }

    public DateTime? ActualFinishStartDt { get; set; }

    public DateTime? ActualFinishEndDt { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
