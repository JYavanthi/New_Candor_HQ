namespace IT_Portal.Domain.IT_Models;

public partial class EssApprover
{
    public int Id { get; set; }

    public string? EssType { get; set; }

    public string? EmployeeNumber { get; set; }

    public int? Priority { get; set; }

    public string? ApproverId { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public string? ReqType { get; set; }
}
