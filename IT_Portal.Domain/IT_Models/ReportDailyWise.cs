namespace IT_Portal.Domain.IT_Models;

public partial class ReportDailyWise
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Pernr { get; set; }

    public TimeOnly? InTime { get; set; }

    public TimeOnly? OutTime { get; set; }

    public string? Status { get; set; }

    public string? Shift { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Location { get; set; }

    public string? Early { get; set; }

    public string? Late { get; set; }

    public string? Total { get; set; }

    public string? Ot { get; set; }

    public bool? AttendanceLockFlag { get; set; }

    public string? CompOff { get; set; }
}
