namespace IT_Portal.Domain.IT_Models;

public partial class UserMaster
{
    public int Id { get; set; }

    public int? FkCompanyId { get; set; }

    public int? FkEmpId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public string? EmployeeId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? PhoneNumber { get; set; }

    public string? ImgUrl { get; set; }

    public int? FkDesignationId { get; set; }

    public int? FkRoleId { get; set; }

    public int? FkSubroleId { get; set; }

    public int? FkProfileId { get; set; }

    public int? FkDepartmentId { get; set; }

    public int? FkUrlId { get; set; }

    public DateTime? LastLoginDateTime { get; set; }

    public string? LastPassword { get; set; }

    public string? PasswordResetToken { get; set; }

    public DateTime? TokenExpiryDate { get; set; }

    public string? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual CompanyMaster? FkCompany { get; set; }
}
