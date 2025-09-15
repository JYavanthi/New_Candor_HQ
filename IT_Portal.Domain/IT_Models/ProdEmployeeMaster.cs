namespace IT_Portal.Domain.IT_Models;

public partial class ProdEmployeeMaster
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? Email { get; set; }

    public int? FkAddressId { get; set; }

    public int? FkOtherDetailsId { get; set; }

    public int? FkProjectId { get; set; }

    public int? FkDesignation { get; set; }

    public int? FkCompetency { get; set; }

    public int? FkDepartment { get; set; }

    public int? FkReportingManager { get; set; }

    public int? FkManager { get; set; }

    public int? FkSbuId { get; set; }

    public int? FkParentId { get; set; }

    public int? FkParentIdCount { get; set; }

    public int? FkApprovalTemplateId { get; set; }

    public int? FkPayroll { get; set; }

    public int? FkProfileId { get; set; }

    public int? FkRoleId { get; set; }

    public string? BaseLocation { get; set; }

    public string? Description { get; set; }

    public int? Interviwer { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? RedirectUrl { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? ImgUrl { get; set; }

    public string? Designation { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? Dol { get; set; }

    public DateOnly? Dob { get; set; }

    public int? DesigRoleId { get; set; }

    public int? HremployeeId { get; set; }
}
