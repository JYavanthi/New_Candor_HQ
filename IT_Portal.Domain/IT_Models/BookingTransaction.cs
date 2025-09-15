namespace IT_Portal.Domain.IT_Models;

public partial class BookingTransaction
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public int? ProcessId { get; set; }

    public string? TransactionType { get; set; }

    public string? MainApprover { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public string? ParallelApprover3 { get; set; }

    public string? ParallelApprover4 { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? BookingApproverId { get; set; }

    public string? Comments { get; set; }

    public int? ApprovalLevel { get; set; }

    public string? CancelComments { get; set; }
}
