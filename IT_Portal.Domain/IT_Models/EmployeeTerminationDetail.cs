namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeTerminationDetail
{
    public int EmployeeTerminationDetailsId { get; set; }

    public int EmployeeId { get; set; }

    public string Status { get; set; } = null!;

    public string Reason { get; set; } = null!;

    public DateTime ApplicableDate { get; set; }

    public string? AdditionalNote { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;
}
