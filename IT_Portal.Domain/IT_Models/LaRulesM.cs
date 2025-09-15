namespace IT_Portal.Domain.IT_Models;

public partial class LaRulesM
{
    public int Id { get; set; }

    public string? RuleId { get; set; }

    public int? Plant { get; set; }

    public int? Paygroup { get; set; }

    public int? Empcat { get; set; }

    public int? AttendanceLateCount { get; set; }

    public string? LeaveApplyAfter { get; set; }

    public string? OdApplyAfter { get; set; }

    public string? ApplyPermissionAfter { get; set; }

    public int? ApplyForgotSwipe { get; set; }

    public int? ApplyPunchMissing { get; set; }

    public string? PermissionCountType { get; set; }

    public int? PermissionCount { get; set; }

    public int? PermissionCountPerMonth { get; set; }

    public int? PermissionHoursPerMonth { get; set; }

    public int? ApplyPermissionAfterMinutesOfShiftStartTime { get; set; }

    public string? SwipeTypePermission { get; set; }

    public int? PerTotMinutes { get; set; }

    public int? PerMinMinutes { get; set; }

    public int? PerMaxMinutes { get; set; }

    public int? AttendanceStatusChangeCount { get; set; }

    public int? MissingPunchesRequestCount { get; set; }

    public int? LopReimbursement { get; set; }

    public string? DeletedReason { get; set; }

    public string? ShiftCode { get; set; }

    public bool? AvailFlexiHours { get; set; }

    public TimeOnly? FlexiStartTime { get; set; }

    public string? WorkHours { get; set; }

    public bool? ShiftAllowance { get; set; }

    public string? AllowanceAmount { get; set; }

    public int? AbsentMailDelay { get; set; }

    public int? ReminderMailDelay { get; set; }

    public int? ReminderCount { get; set; }

    public int? ActionMailDelay { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual EmpCategoryMaster? EmpcatNavigation { get; set; }

    public virtual PaygroupMaster? PaygroupNavigation { get; set; }

    public virtual PlantMaster? PlantNavigation { get; set; }
}
