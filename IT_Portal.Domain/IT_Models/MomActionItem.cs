namespace IT_Portal.Domain.IT_Models;

public partial class MomActionItem
{
    public int Id { get; set; }

    public int? MeetingId { get; set; }

    public string? ActionItem { get; set; }

    public string? Priority { get; set; }

    public string? Responsibility { get; set; }

    public string? EmployeeNo { get; set; }

    public string? Department { get; set; }

    public string? Name { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public DateTime? Tcd { get; set; }

    public string? Status { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual MinutesOfMeeting? Meeting { get; set; }

    public virtual ICollection<TaskManager> TaskManagers { get; set; } = new List<TaskManager>();
}
