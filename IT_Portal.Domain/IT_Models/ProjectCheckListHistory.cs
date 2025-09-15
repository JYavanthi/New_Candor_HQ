namespace IT_Portal.Domain.IT_Models;

public partial class ProjectCheckListHistory
{
    public int ClhistoryId { get; set; }

    public int? CheckListId { get; set; }

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
}
