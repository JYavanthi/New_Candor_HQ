namespace IT_Portal.Domain.IT_Models;

public partial class MeetingSummary
{
    public int SummaryId { get; set; }

    public int? MeetingId { get; set; }

    public string? Summary { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual MinutesOfMeeting? Meeting { get; set; }
}
