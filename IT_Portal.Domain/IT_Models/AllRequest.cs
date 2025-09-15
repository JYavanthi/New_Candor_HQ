namespace IT_Portal.Domain.IT_Models;

public partial class AllRequest
{
    public int Id { get; set; }

    public string? ReqNo { get; set; }

    public string? ReqType { get; set; }

    public DateTime? ReqDate { get; set; }

    public string? ReqStatus { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? RequesterId { get; set; }

    public string? Comments { get; set; }

    public DateTime? DoneOn { get; set; }

    public string? HrId { get; set; }
}
