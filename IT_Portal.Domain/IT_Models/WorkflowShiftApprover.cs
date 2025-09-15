namespace IT_Portal.Domain.IT_Models;

public partial class WorkflowShiftApprover
{
    public int Id { get; set; }

    public int WorkflowApproverId { get; set; }

    public bool IsActive { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string ApproverId { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
