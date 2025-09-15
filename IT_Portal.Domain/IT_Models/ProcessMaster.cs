namespace IT_Portal.Domain.IT_Models;

public partial class ProcessMaster
{
    public int ProcessId { get; set; }

    public string? ProcessName { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<WorkFlowApprover> WorkFlowApprovers { get; set; } = new List<WorkFlowApprover>();
}
