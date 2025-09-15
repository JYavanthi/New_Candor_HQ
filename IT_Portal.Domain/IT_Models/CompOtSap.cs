namespace IT_Portal.Domain.IT_Models;

public partial class CompOtSap
{
    public int Id { get; set; }

    public int? CalendarYear { get; set; }

    public int? SalaryPayGroup { get; set; }

    public int? EmployeeNumber { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public double? NumberOfDays { get; set; }

    public string? ActualTime { get; set; }

    public string? FromTime { get; set; }

    public string? EndTime { get; set; }

    public DateOnly? CompOffAvailedDate { get; set; }

    public double? CompOffAvailedDays { get; set; }

    public double? CompOffBalance { get; set; }

    public int? NumberOfHours { get; set; }

    public int? CompAccumulatedHours { get; set; }

    public DateOnly? LapsBydate { get; set; }

    public int? LeavReqNo { get; set; }

    public int? RequestedBy { get; set; }

    public DateOnly? RequestedDate { get; set; }

    public string? Remarks { get; set; }

    public string? UserName { get; set; }

    public DateOnly? CreationDate { get; set; }

    public string? TimeOfEntry { get; set; }

    public DateOnly? ChangedOn { get; set; }

    public string? LastChangedBy { get; set; }

    public string? SapUpdated { get; set; }

    public string? SapMessage { get; set; }

    public DateTime? SapUpdatedDate { get; set; }

    public DateTime? ProcessdDate { get; set; }
}
