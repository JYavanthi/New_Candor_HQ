namespace IT_Portal.Domain.IT_Models;

public partial class DailyAttendanceSummaryCount
{
    public DateOnly? AttendanceDate { get; set; }

    public string? Location { get; set; }

    public int? StaffApprovedstrength { get; set; }

    public int? TechstaffApprovedstrength { get; set; }

    public int? HouseKeepingApprovedstrength { get; set; }

    public int? G4sApprovedstrength { get; set; }

    public int? ApprenticeApprovedstrength { get; set; }

    public int? ContractorApprovedstrength { get; set; }

    public int? TotalApprovedstrength { get; set; }

    public int? StaffAvlstrength { get; set; }

    public int? TechstaffAvlstrength { get; set; }

    public int? HouseKeepingAvlstrength { get; set; }

    public int? G4sAvlstrength { get; set; }

    public int? ApprenticeAvlstrength { get; set; }

    public int? ContractorAvlstrength { get; set; }

    public int? TotalAvlstrength { get; set; }

    public int? StaffPresent { get; set; }

    public int? TechstaffPresent { get; set; }

    public int? HouseKeepingPresent { get; set; }

    public int? G4sPresent { get; set; }

    public int? ApprenticePresent { get; set; }

    public int? ContractorPresent { get; set; }

    public int? TotalPresent { get; set; }

    public int? SaffAbsent { get; set; }

    public int? TechstaffAbsent { get; set; }

    public int? HouseKeepingAbsent { get; set; }

    public int? G4sAbsent { get; set; }

    public int? ApprenticeAbsent { get; set; }

    public int? ContractorAbsent { get; set; }

    public int? TotalAbsent { get; set; }

    public int? StaffOnduty { get; set; }

    public int? TechstaffOnduty { get; set; }

    public int? HouseKeepingOnduty { get; set; }

    public int? G4sOnduty { get; set; }

    public int? ApprenticeOnduty { get; set; }

    public int? ContractorOnduty { get; set; }

    public int? TotalOnduty { get; set; }

    public int? StaffLeave { get; set; }

    public int? TechstaffLeave { get; set; }

    public int? HouseKeepingLeave { get; set; }

    public int? G4sLeave { get; set; }

    public int? ApprenticeLeave { get; set; }

    public int? ContractorLeave { get; set; }

    public int? TotalLeave { get; set; }

    public int? StaffWeeklyOff { get; set; }

    public int? TechStaffWeeklyOff { get; set; }

    public int? HouseKeepingWeeklyOff { get; set; }

    public int? G4sWeeklyOff { get; set; }

    public int? ApprenticeWeeklyOff { get; set; }

    public int? ContractorWeeklyOff { get; set; }

    public double? StaffPercentage { get; set; }

    public double? TechstaffPercentage { get; set; }

    public double? HouseKeepingPercentage { get; set; }

    public double? G4sPercentage { get; set; }

    public double? ApprenticePercentage { get; set; }

    public double? ContracorPercentage { get; set; }

    public double? TotalPercentage { get; set; }

    public DateTime? ShcedularDate { get; set; }
}
