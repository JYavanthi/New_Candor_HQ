namespace IT_Portal.Domain.IT_Models;

public partial class HrQuery
{
    public int Id { get; set; }

    public string? ReqBy { get; set; }

    public DateTime? ReqDate { get; set; }

    public string? Status { get; set; }

    public string? Category { get; set; }

    public string? Role { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? PendingApprover { get; set; }

    public string? LastApprover { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? Comments { get; set; }
}
