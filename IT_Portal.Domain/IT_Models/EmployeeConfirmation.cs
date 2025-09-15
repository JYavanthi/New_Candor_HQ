namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeConfirmation
{
    public int EmployeeConfirmationId { get; set; }

    public int EmployeeId { get; set; }

    public string? Status { get; set; }

    public int SubmitedById { get; set; }

    public string? Comments { get; set; }

    public int HodId { get; set; }

    public string? PerformanceRating { get; set; }

    public string? Achievement { get; set; }

    public string? CurrentJobResponsibilty { get; set; }

    public string? JobChangeDetails { get; set; }

    public DateTime? NextConfirmation { get; set; }

    public string? Reason { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? NewJobResponsibility { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeeMaster Hod { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;

    public virtual EmployeeMaster SubmitedBy { get; set; } = null!;
}
