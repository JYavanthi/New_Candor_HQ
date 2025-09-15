namespace IT_Portal.Domain.IT_Models;

public partial class FlowTaskApprover
{
    public int FlowTaskApproverId { get; set; }

    public int FlowTaskId { get; set; }

    public int ApproverId { get; set; }
}
