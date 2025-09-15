namespace IT_Portal.Domain.IT_Models;

public partial class TourPlan
{
    public int Id { get; set; }

    public string? ReqBy { get; set; }

    public DateTime? ReqOn { get; set; }

    public DateTime? Date { get; set; }

    public string? Duration { get; set; }

    public string? TypeOfWork { get; set; }

    public string? Details { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? ApproverStatus { get; set; }

    public string? Comments { get; set; }
}
