namespace IT_Portal.Domain.IT_Models;

public partial class ProdApprovalTransaction
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? ProcessType { get; set; }

    public int? TransactionType { get; set; }

    public int? ApprovalPriority { get; set; }

    public string? Comments { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public string? ParallelApprover3 { get; set; }

    public string? ParallelApprover4 { get; set; }

    public string? KeyValue { get; set; }

    public string? ParallelApprover5 { get; set; }
}
