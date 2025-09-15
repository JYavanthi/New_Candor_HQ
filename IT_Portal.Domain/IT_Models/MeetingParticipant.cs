namespace IT_Portal.Domain.IT_Models;

public partial class MeetingParticipant
{
    public int ParticipantId { get; set; }

    public int? MeetingId { get; set; }

    public string? ParticipantType { get; set; }

    public string? EmployeeId { get; set; }

    public string? ParticipantName { get; set; }

    public string? Department { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public string? Mode { get; set; }

    public string? Attendance { get; set; }

    public virtual MinutesOfMeeting? Meeting { get; set; }
}
