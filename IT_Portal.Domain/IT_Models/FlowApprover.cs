namespace IT_Portal.Domain.IT_Models;

public partial class FlowApprover
{
    public int FlowApproverId { get; set; }

    public int PlantId { get; set; }

    public int PayGroupId { get; set; }

    public int EmployeeCategoryId { get; set; }

    public string FlowType { get; set; } = null!;

    public int ApproverId { get; set; }

    public int ApproverOrder { get; set; }

    public bool AutoApprove { get; set; }

    public int ApproveInDays { get; set; }
}
