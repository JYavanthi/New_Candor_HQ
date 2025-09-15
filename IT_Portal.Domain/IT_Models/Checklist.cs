namespace IT_Portal.Domain.IT_Models;

public partial class Checklist
{
    public int ItchecklistId { get; set; }

    public int? PlantId { get; set; }

    public int SupportId { get; set; }

    public int CategoryId { get; set; }

    public int ClassificationId { get; set; }

    public string ChecklistTitle { get; set; } = null!;

    public string ChecklistDesc { get; set; } = null!;

    public bool? MandatoryFlag { get; set; }

    public int? ApproverId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? Status { get; set; }

    public virtual Support Support { get; set; } = null!;
}
