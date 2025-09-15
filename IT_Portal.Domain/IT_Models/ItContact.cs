namespace IT_Portal.Domain.IT_Models;

public partial class ItContact
{
    public int Id { get; set; }

    public string? BriefResponsibility { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public string? DetailedResponsibility { get; set; }

    public DateOnly? DateOfJoining { get; set; }

    public string? Designation { get; set; }

    public string? EmailId { get; set; }

    public string? EmployeeNo { get; set; }

    public string? EmployeeName { get; set; }

    public string? Hod { get; set; }

    public string? Extension { get; set; }

    public string? MobileNo { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Photo { get; set; }

    public string? ReportingManager { get; set; }

    public string? Role { get; set; }

    public string? SittingLocation { get; set; }

    public bool? IsActive { get; set; }
}
