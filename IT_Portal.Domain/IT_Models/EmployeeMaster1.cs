namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeMaster1
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? Email { get; set; }

    public string FkAddressId { get; set; } = null!;

    public string FkOtherDetailsId { get; set; } = null!;

    public int FkProjectId { get; set; }

    public int? FkDesignation { get; set; }

    public int FkCompetency { get; set; }

    public int? FkDepartment { get; set; }

    public string? FkReportingManager { get; set; }

    public string? FkManager { get; set; }

    public int FkSbuId { get; set; }

    public string? FkParentId { get; set; }

    public int FkParentIdCount { get; set; }

    public int FkApprovalTemplateId { get; set; }

    public int? FkPayroll { get; set; }

    public int FkProfileId { get; set; }

    public int FkRoleId { get; set; }

    public int BaseLocation { get; set; }

    public string Description { get; set; } = null!;

    public int? Interviwer { get; set; }

    public int? JoiningDate { get; set; }

    public int? RedirectUrl { get; set; }

    public string? FirstName { get; set; }

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ImgUrl { get; set; } = null!;

    public string? Designation { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int IsActive { get; set; }
}
