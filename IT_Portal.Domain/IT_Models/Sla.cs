namespace IT_Portal.Domain.IT_Models;

public partial class Sla
{
    public int Itslaid { get; set; }

    public int CategoryId { get; set; }

    public int ClassificationId { get; set; }

    public int? CategoryTypId { get; set; }

    public int SupportId { get; set; }

    public int? WaitTime { get; set; }

    public string? WaitTimeUnit { get; set; }

    public int? AssignedTo { get; set; }

    public int? PlantId { get; set; }

    public int? Escalation1 { get; set; }

    public int? WaitTimeEscal1 { get; set; }

    public string? WaitTimeUnitEscal1 { get; set; }

    public int? Escalation2 { get; set; }

    public int? WaitTimeEscal2 { get; set; }

    public string? WaitTimeUnitEscal2 { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Classification Classification { get; set; } = null!;

    public virtual PlantMaster? Plant { get; set; }

    public virtual Support Support { get; set; } = null!;
}
