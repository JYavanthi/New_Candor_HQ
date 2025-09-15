namespace IT_Portal.Domain.IT_Models;

public partial class RiskPlan
{
    public int ItriskId { get; set; }

    public int? PlantId { get; set; }

    public int SupportId { get; set; }

    public int CategoryId { get; set; }

    public string? TestPlan { get; set; }

    public string? TestPlanAttachment { get; set; }

    public string? CommunicationPlan { get; set; }

    public string? CommunicationPlanAttachment { get; set; }

    public string? CommunicationDays { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Support Support { get; set; } = null!;
}
