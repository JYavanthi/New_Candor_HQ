namespace IT_Portal.Domain.IT_Models;

public partial class Flow
{
    public int FlowId { get; set; }

    public string FlowType { get; set; } = null!;

    public int ObjectId { get; set; }

    public string ObjectType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Result { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? InitialData { get; set; }

    public string? LastData { get; set; }

    public string? ActivityTrace { get; set; }

    public int InitiatedById { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }
}
