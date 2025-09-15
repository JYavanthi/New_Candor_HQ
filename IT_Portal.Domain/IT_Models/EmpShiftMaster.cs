namespace IT_Portal.Domain.IT_Models;

public partial class EmpShiftMaster
{
    public int Id { get; set; }

    public string? ShiftCode { get; set; }

    public string? ShiftName { get; set; }

    public string? RuleCode { get; set; }

    public bool? NightShift { get; set; }

    public string? DeductBreakUp { get; set; }

    public TimeOnly? ShiftStartTime { get; set; }

    public TimeOnly? FirstHalfEndTime { get; set; }

    public TimeOnly? ShStartTime { get; set; }

    public TimeOnly? ShiftEndTime { get; set; }

    public TimeOnly? TotalShiftTime { get; set; }

    public TimeOnly? FirstBreakStartTime { get; set; }

    public TimeOnly? FirstBreakEndTime { get; set; }

    public TimeOnly? SecondBreakStartTime { get; set; }

    public TimeOnly? SecondBreakEndTime { get; set; }

    public TimeOnly? ThirdBreakStartTime { get; set; }

    public TimeOnly? ThirdBreakEndTime { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Username { get; set; }

    public TimeOnly? PunchStartTime { get; set; }

    public TimeOnly? PunchEndTime { get; set; }

    public TimeOnly? ComeLate { get; set; }

    public TimeOnly? GoEarly { get; set; }

    public TimeOnly? PunchValidTill { get; set; }

    public int? OtFull { get; set; }

    public int? OtHalf { get; set; }

    public string? Loc { get; set; }

    public string? Stxt { get; set; }

    public int? WfhFlag { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string? DeletedReason { get; set; }

    public TimeOnly? ShiftGraceTime { get; set; }

    public bool? AvailFlexiHours { get; set; }

    public TimeOnly? FlexiStartTime { get; set; }

    public string? WorkHours { get; set; }

    public bool? ShiftAllowance { get; set; }

    public string? AllowanceAmount { get; set; }
}
