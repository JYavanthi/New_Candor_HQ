namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeRetirementDetail
{
    public int EmployeeRetirementDetailsId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime SubmittedDate { get; set; }

    public DateTime ExtendedDate { get; set; }

    public string Remarks { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? ApprovalDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;
}
