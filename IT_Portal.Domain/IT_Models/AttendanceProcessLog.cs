namespace IT_Portal.Domain.IT_Models;

public partial class AttendanceProcessLog
{
    public int Id { get; set; }

    public string? EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? EmpLoc { get; set; }

    public string? ProcessName { get; set; }

    public string? ProcessLocation { get; set; }

    public string? ProcessParameter { get; set; }

    public string? ProcessStatus { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? LockId { get; set; }

    public DateTime? Date { get; set; }

    public int? EmpCount { get; set; }

    public DateTime? FetchSt { get; set; }

    public DateTime? FetchEt { get; set; }

    public DateTime? LeaveSt { get; set; }

    public DateTime? LeaveEt { get; set; }

    public DateTime? PunchSt { get; set; }

    public DateTime? PunchEt { get; set; }

    public DateTime? ManualSt { get; set; }

    public DateTime? ManualEt { get; set; }

    public DateTime? WeekSt { get; set; }

    public DateTime? WeekEt { get; set; }

    public DateTime? RepSt { get; set; }

    public DateTime? RepEt { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public int? Progress { get; set; }
}
