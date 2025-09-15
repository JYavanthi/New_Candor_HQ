namespace IT_Portal.Domain.IT_Models;

public partial class PayrollRegularizationRequest
{
    public int Id { get; set; }

    public int? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? RequestedBy { get; set; }

    public string? UserId { get; set; }

    public string? SwipeType { get; set; }

    public DateTime? Date { get; set; }

    public string? Time { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public string? PendingApprover { get; set; }

    public string? LastApprover { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? Comments { get; set; }

    public bool? Cancelflag { get; set; }
}
