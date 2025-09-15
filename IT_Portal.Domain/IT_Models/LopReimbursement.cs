namespace IT_Portal.Domain.IT_Models;

public partial class LopReimbursement
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public string? PendingApprover { get; set; }

    public string? LastApprover { get; set; }

    public double? NoofDays { get; set; }

    public DateTime? SubmittedDate { get; set; }

    public string? SubmittedBy { get; set; }
}
