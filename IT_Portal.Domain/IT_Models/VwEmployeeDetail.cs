namespace IT_Portal.Domain.IT_Models;

public partial class VwEmployeeDetail
{
    public string EmployeeId { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? TelephoneNo { get; set; }

    public string? MobileNo { get; set; }

    public string? OfficialEmailId { get; set; }

    public string? Department { get; set; }

    public DateTime DateOfJoining { get; set; }

    public int DesignationId { get; set; }

    public string? Designation { get; set; }

    public DateTime? DateOfLeaving { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int ReportingManagerId { get; set; }

    public string? ReportManagerName { get; set; }

    public string? PayGroup { get; set; }

    public string? Role { get; set; }

    public string? StaffCategory { get; set; }

    public string? Plantcode { get; set; }
}
