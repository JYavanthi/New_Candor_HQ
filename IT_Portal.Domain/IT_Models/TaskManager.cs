namespace IT_Portal.Domain.IT_Models;

public partial class TaskManager
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? TaskName { get; set; }

    public int TaskAssignedTo { get; set; }

    public string? TaskAssigType { get; set; }

    public int? TaskAssignedBy { get; set; }

    public DateTime? Momdate { get; set; }

    public string? Mompurpose { get; set; }

    public string? ProjectName { get; set; }

    public string? ChangeRequestName { get; set; }

    public string? Details { get; set; }

    public DateTime? Tcd { get; set; }

    public string? TaskStatus { get; set; }

    public string? RemainderBeforeDays { get; set; }

    public string? ClosureReasonType { get; set; }

    public string? ClosureReason { get; set; }

    public DateTime? ActualClosureDate { get; set; }

    public DateTime? TaskAssignedOn { get; set; }

    public string? DeletedReason { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string? TaskClosedBy { get; set; }

    public string? TaskAssignedToName { get; set; }

    public string? ApplicablePlants { get; set; }

    public int? MomactionId { get; set; }

    public int? MeetingId { get; set; }

    public string? Priority { get; set; }

    public string? ApplicableProject { get; set; }

    public virtual MinutesOfMeeting? Meeting { get; set; }

    public virtual MomActionItem? Momaction { get; set; }

    public virtual EmployeeMaster? TaskAssignedByNavigation { get; set; }

    public virtual EmployeeMaster TaskAssignedToNavigation { get; set; } = null!;

    public virtual ICollection<TaskAttachment> TaskAttachments { get; set; } = new List<TaskAttachment>();
}
