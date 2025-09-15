namespace IT_Portal.Domain.IT_Models;

public partial class ProdEmployeeAddress
{
    public int Id { get; set; }

    public int? FkEmpId { get; set; }

    public string? EmployeeId { get; set; }

    public string? PersonalEmail { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmgContactNumber { get; set; }

    public string? EmgContactName { get; set; }

    public string? CurrentAddress { get; set; }

    public string? PermanentAddress { get; set; }

    public string? NomineeName { get; set; }

    public string? NomineePhone { get; set; }

    public string? GuardianName { get; set; }

    public string? GuardianRelation { get; set; }

    public string? GuardianPhone { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? ModuleEnableId { get; set; }
}
