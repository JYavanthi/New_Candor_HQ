namespace IT_Portal.Domain.IT_Models;

public partial class NewCandidate
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddelName { get; set; }

    public string? LastName { get; set; }

    public string? PersonalEmail { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Designation { get; set; }

    public string? PassportNumber { get; set; }

    public string? PanNumber { get; set; }

    public bool? VisaIsActive { get; set; }

    public string? VisaNumber { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? RedirectUrl { get; set; }

    public string? Passport { get; set; }

    public int? Competency { get; set; }

    public int? Department { get; set; }

    public int? SubDepartment { get; set; }

    public int? ReportingManager { get; set; }

    public int? Manager { get; set; }

    public string? HardSkill { get; set; }

    public string? SoftSkill { get; set; }

    public string? Description { get; set; }

    public int? YearExp { get; set; }

    public int? RelativeExp { get; set; }

    public string? LastCompany { get; set; }

    public string? SecondLastCompany { get; set; }

    public string? PreviousLocation { get; set; }

    public string? CurrentLocation { get; set; }

    public int? Interviwer { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
