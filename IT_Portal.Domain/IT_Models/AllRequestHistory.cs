namespace IT_Portal.Domain.IT_Models;

public partial class AllRequestHistory
{
    public int Id { get; set; }

    public string? RequestType { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestedDate { get; set; }

    public string? RequestedBy { get; set; }

    public string? RequestStatus { get; set; }

    public string? PendingApprover { get; set; }

    public string? LastApprover { get; set; }

    public string? Comments { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public int? Priority { get; set; }

    public string? ActualApprover { get; set; }
}
