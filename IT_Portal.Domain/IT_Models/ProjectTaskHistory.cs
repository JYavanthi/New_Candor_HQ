using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class ProjectTaskHistory
{
    public int HistoryId { get; set; }

    public int TaskId { get; set; }

    public int MilestoneId { get; set; }

    public string? TaskCode { get; set; }

    public int ProjectId { get; set; }

    public int Owner { get; set; }

    public int EmpId { get; set; }

    public int AssignTo { get; set; }

    public int Duration { get; set; }

    public int? ParentTaskId { get; set; }

    public bool? Responsible { get; set; }

    public bool? Accountable { get; set; }

    public bool? Consulted { get; set; }

    public bool? Informed { get; set; }

    public string? TaskTitle { get; set; }

    public string? TaskDesc { get; set; }

    public string? Prority { get; set; }

    public string? Priority { get; set; }

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
}
