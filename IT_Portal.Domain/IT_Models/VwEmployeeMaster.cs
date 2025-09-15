namespace IT_Portal.Domain.IT_Models;

public partial class VwEmployeeMaster
{
    public string? EmployeeId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? EmployeeName { get; set; }

    public string? ImgUrl { get; set; }

    public string? Designation { get; set; }

    public DateTime? Dol { get; set; }

    public DateOnly? Dob { get; set; }

    public int? ReportingManagerId { get; set; }

    public string? ReportManagerName { get; set; }

    public string? Department { get; set; }

    public string? PayGroup { get; set; }

    public string? Role { get; set; }

    public string? StaffCategory { get; set; }

    public string? Plantcode { get; set; }
}
