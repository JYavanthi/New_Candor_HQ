namespace IT_Portal.Domain.IT_Models;

public partial class EmployeePayroll
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public int? CurrentAnnualCtc { get; set; }

    public int? FixedCtc { get; set; }

    public int? VeriablePay { get; set; }

    public string? CurrentWorkStatus { get; set; }

    public int? BillingRate { get; set; }

    public DateOnly? PreviousAppraisalDate { get; set; }

    public DateOnly? AppraisalDueDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
