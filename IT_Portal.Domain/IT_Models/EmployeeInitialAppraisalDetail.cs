namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeInitialAppraisalDetail
{
    public int EmployeeInitialAppraisalDetailId { get; set; }

    public int InitiatedById { get; set; }

    public DateTime InitiatedDate { get; set; }

    public int? HodId { get; set; }

    public string AppraisalType { get; set; } = null!;

    public string? Rating { get; set; }

    public string? OldResponsibilities { get; set; }

    public string? SpecialAchievement { get; set; }

    public string? NextYearKra { get; set; }

    public int? RecommendedDesignationId { get; set; }

    public int? RecommendedRoleId { get; set; }

    public decimal? RecommendedSalary { get; set; }

    public string? Status { get; set; }

    public string AppraisalInitiatorType { get; set; } = null!;

    public DateTime? InitialAppraisalApprovedDate { get; set; }

    public int EmployeeId { get; set; }

    public string? Comment { get; set; }

    public string? NewResponsibilities { get; set; }

    public virtual EmployeeMaster? Hod { get; set; }

    public virtual EmployeeMaster InitiatedBy { get; set; } = null!;

    public virtual DesignationMaster? RecommendedDesignation { get; set; }

    public virtual RoleMaster? RecommendedRole { get; set; }
}
