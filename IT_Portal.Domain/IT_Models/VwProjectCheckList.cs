using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwProjectCheckList
{
    public int CheckListId { get; set; }

    public string? CheckListTitle { get; set; }

    public int? TaskId { get; set; }

    public int? ProjectMgmtId { get; set; }

    public int? SubTaskId { get; set; }

    public int? MileStoneId { get; set; }

    public string? ProjectLevel { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? ProjectName { get; set; }

    public string? MilestoneTitle { get; set; }

    public string? TaskTitle { get; set; }

    public string? SubTaskTitle { get; set; }
}
