namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeOtherDetail
{
    public int Id { get; set; }

    public int? FkEmpId { get; set; }

    public string? EmployeeId { get; set; }

    public int? Designation { get; set; }

    public string? PanNumber { get; set; }

    public bool? VisaIsActive { get; set; }

    public string? VisaNumber { get; set; }

    public string? PassportNumber { get; set; }

    public string? Qualification { get; set; }

    public string? YearOfPassing { get; set; }

    public string? HardSkill { get; set; }

    public string? SoftSkill { get; set; }

    public string? Description { get; set; }

    public int? YearExp { get; set; }

    public int? RelativeExp { get; set; }

    public string? LastCompany { get; set; }

    public string? SecondLastCompany { get; set; }

    public string? PreviousLocation { get; set; }

    public string? CurrentLocation { get; set; }

    public string? ImgUrl { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Gender { get; set; }
}
