namespace IT_Portal.Domain.IT_Models;

public partial class ChangeShiftLog
{
    public int Id { get; set; }

    public int? ReqNo { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestedDate { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public string? PreviousShift { get; set; }

    public string? UpdatedShift { get; set; }

    public string? Reason { get; set; }

    public string? ApprovalStatus { get; set; }

    public string? ApproverId { get; set; }

    public string? PendingApprover { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? Comments { get; set; }
}
