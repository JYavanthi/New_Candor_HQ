namespace IT_Portal.Domain.IT_Models;

public partial class FlowTask
{
    public int FlowTaskId { get; set; }

    public int FlowId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Result { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? InitialData { get; set; }

    public string? LastData { get; set; }

    public string? ActivityTrace { get; set; }

    public string Role { get; set; } = null!;

    public int? CompletedById { get; set; }

    public int Order { get; set; }

    public bool AutoApprove { get; set; }

    public int ApproveInDays { get; set; }
}
