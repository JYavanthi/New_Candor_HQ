namespace IT_Portal.Domain.IT_Models;

public partial class EmpHolidayCalendarMapping
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string? Plant { get; set; }

    public int? SwipeCount { get; set; }

    public string Holiday { get; set; } = null!;

    public string? TypeCodeH { get; set; }

    public string? TypeNameH { get; set; }

    public string CalendarType { get; set; } = null!;

    public string? TypeCodeC { get; set; }

    public string? TypeNameC { get; set; }

    public string? MediclaimNo { get; set; }

    public DateTime? MediclaimExpiry { get; set; }

    public string? MediclaimorEsi { get; set; }

    public string? WorkType { get; set; }

    public string? BiometricPunchingDevice { get; set; }

    public string? BiometricSwipeId { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
