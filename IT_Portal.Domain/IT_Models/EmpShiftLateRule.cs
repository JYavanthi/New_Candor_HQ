namespace IT_Portal.Domain.IT_Models;

public partial class EmpShiftLateRule
{
    public int Id { get; set; }

    public string? RuleCode { get; set; }

    public string? RuleName { get; set; }

    public TimeOnly? ComeLateBy { get; set; }

    public TimeOnly? GoEarlyBy { get; set; }

    public TimeOnly? IgnoreEarlyArrivalBeforeShiftBy { get; set; }

    public TimeOnly? IgnoreLateGoingAfterShiftBy { get; set; }

    public TimeOnly? DeductHalfDayIfLateComingBy { get; set; }

    public TimeOnly? CutHalfDayIfEarlyGoingBy { get; set; }

    public int? NumberOfLateCountsAllowedPerMonth { get; set; }

    public int? NoOfEarlyCount { get; set; }

    public bool? LopForLateComing { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Username { get; set; }

    public string? Loc { get; set; }
}
