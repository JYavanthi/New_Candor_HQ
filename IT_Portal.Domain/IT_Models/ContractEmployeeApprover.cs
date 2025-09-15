namespace IT_Portal.Domain.IT_Models;

public partial class ContractEmployeeApprover
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? ApproverId { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public int? Priority { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
