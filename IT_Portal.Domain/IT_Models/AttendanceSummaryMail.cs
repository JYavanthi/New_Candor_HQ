namespace IT_Portal.Domain.IT_Models;

public partial class AttendanceSummaryMail
{
    public string? Location { get; set; }

    public TimeOnly? Time { get; set; }

    public string? MailTo { get; set; }

    public string? Displayname { get; set; }

    public string? MailToCc { get; set; }

    public string? MailToBcc { get; set; }

    public string? ReportingGrp { get; set; }
}
