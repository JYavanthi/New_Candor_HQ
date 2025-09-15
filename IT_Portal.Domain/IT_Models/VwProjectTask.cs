namespace IT_Portal.Domain.IT_Models;

public partial class VwProjectTask
{
    public int TaskId { get; set; }

    public int MilestoneId { get; set; }

    public int ProjectId { get; set; }

    public int Owner { get; set; }

    public int EmpId { get; set; }

    public int AssignTo { get; set; }

    public int Duration { get; set; }

    public bool? Responsible { get; set; }

    public decimal? ActualCost { get; set; }

    public decimal? PlannedCost { get; set; }

    public bool? Accountable { get; set; }

    public bool? Consulted { get; set; }

    public string? Dependency { get; set; }

    public bool? Informed { get; set; }

    public string? TaskTitle { get; set; }

    public string? TaskDesc { get; set; }

    public string? TaskPriority { get; set; }

    public string? WorkHours { get; set; }

    public string? Status { get; set; }

    public DateTime? CompletionDate { get; set; }

    public DateTime? StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int ParentTaskId { get; set; }

    public string? TaskCode { get; set; }

    public string? Projectphase { get; set; }

    public bool? IsSubtask { get; set; }

    public string? ParentTaskTitel { get; set; }

    public string? MilestoneTitle { get; set; }

    public string? ProjectName { get; set; }

    public int? ProjectOwner { get; set; }

    public string? AdditionalNotes { get; set; }

    public DateTime? ActualStartDt { get; set; }

    public DateTime? ActualEndDt { get; set; }
}
