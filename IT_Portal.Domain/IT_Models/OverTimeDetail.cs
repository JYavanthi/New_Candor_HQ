namespace IT_Portal.Domain.IT_Models;

public partial class OverTimeDetail
{
    public int Id { get; set; }

    public int? ReqNo { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public string? Pernr { get; set; }

    public string? NoHrs { get; set; }

    public string? Applicabale { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestedDate { get; set; }

    public DateTime? ApprvdDate { get; set; }

    public string? Reason { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public int? Cancelflag { get; set; }
}
