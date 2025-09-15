namespace IT_Portal.Domain.IT_Models;

public partial class AbsentMailTracking
{
    public int Id { get; set; }

    public string EmployeeNo { get; set; } = null!;

    public DateOnly? AbsentFromDate { get; set; }

    public DateOnly? AbsentToDate { get; set; }

    public bool AbsentMailSent { get; set; }

    public bool ReminderMailSent { get; set; }

    public int ReminderMailCount { get; set; }

    public string? SentToMailIds { get; set; }

    public string? SentFromMailId { get; set; }

    public DateTime? AbsentMailSentOn { get; set; }

    public DateTime? ReminderMailSentOn { get; set; }
}
