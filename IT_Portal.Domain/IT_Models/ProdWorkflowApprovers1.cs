namespace IT_Portal.Domain.IT_Models;

public partial class ProdWorkflowApprovers1
{
    public int Id { get; set; }

    public string? KeyValue { get; set; }

    public string? ApproverId { get; set; }

    public int? Priority { get; set; }

    public string? ParllelApprover1 { get; set; }

    public string? ParllelApprover2 { get; set; }

    public string? ParllelApprover3 { get; set; }

    public string? ParllelApprover4 { get; set; }

    public string? Role { get; set; }

    public int? ProcessId { get; set; }

    public bool? Closure { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public string? Dept { get; set; }

    public string? ParllelApprover5 { get; set; }
}
