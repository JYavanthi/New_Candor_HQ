namespace IT_Portal.Domain.IT_Models;

public partial class MinutesOfMeeting
{
    public int MeetingId { get; set; }

    public string MeetingType { get; set; } = null!;

    public string? MeetingPurpose { get; set; }

    public DateTime MeetingDate { get; set; }

    public DateTime? MeetingFrom { get; set; }

    public DateTime? MeetingTo { get; set; }

    public string? LocationType { get; set; }

    public string? MeetingLocation { get; set; }

    public string? Room { get; set; }

    public string? Mode { get; set; }

    public string? RecordedBy { get; set; }

    public string? MeetingAgenda { get; set; }

    public DateTime? NextMeetingDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Project { get; set; }

    public bool? Archived { get; set; }

    public string? CreatorEmailId { get; set; }

    public virtual ICollection<MeetingParticipant> MeetingParticipants { get; set; } = new List<MeetingParticipant>();

    public virtual ICollection<MeetingSummary> MeetingSummaries { get; set; } = new List<MeetingSummary>();

    public virtual ICollection<MomActionItem> MomActionItems { get; set; } = new List<MomActionItem>();

    public virtual ICollection<TaskManager> TaskManagers { get; set; } = new List<TaskManager>();
}
