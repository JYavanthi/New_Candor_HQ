namespace IT_Portal.Domain.IT_Models;

public partial class ProdGigoapprovalTransaction
{
    public int Id { get; set; }

    public string? KeyValue { get; set; }

    public string? Gonumber { get; set; }

    public string? TransactionType { get; set; }

    public int? ApprovalStage { get; set; }

    public string? Role { get; set; }

    public string? Department { get; set; }

    public string? Comments { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedOn { get; set; }

    public string? MainApprover { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public string? ParallelApprover3 { get; set; }

    public string? ParallelApprover4 { get; set; }

    public string? ParallelApprover5 { get; set; }
}
