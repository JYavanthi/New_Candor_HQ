namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeAppraisal
{
    public int EmployeeAppraisalId { get; set; }

    public int EmployeeId { get; set; }

    public string Status { get; set; } = null!;

    public bool IsTransfer { get; set; }

    public bool IsSalaryChange { get; set; }

    public bool IsRoleChange { get; set; }

    public bool IsDesignationChange { get; set; }

    public bool IsStaffCategoryChange { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime EffectiveDate { get; set; }

    public string PerformanceRating { get; set; } = null!;

    public string AppraisalType { get; set; } = null!;

    public string JobChangeDetails { get; set; } = null!;

    public int AppraisedById { get; set; }

    public int ApprovedById { get; set; }

    public DateTime SalaryProcessingMonth { get; set; }

    public string? Note { get; set; }

    public string? AdHocNote { get; set; }

    public string PackageType { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<EmployeeAppraisalSalary> EmployeeAppraisalSalaries { get; set; } = new List<EmployeeAppraisalSalary>();
}
