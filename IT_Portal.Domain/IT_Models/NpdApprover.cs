namespace IT_Portal.Domain.IT_Models;

public partial class NpdApprover
{
    public int Id { get; set; }

    public string? ReqType { get; set; }

    public string? Department { get; set; }

    public int? Priority { get; set; }

    public string? ApproverId { get; set; }

    public string? ApproverName { get; set; }

    public string? EmailId { get; set; }
}
