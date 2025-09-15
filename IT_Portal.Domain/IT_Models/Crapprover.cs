namespace IT_Portal.Domain.IT_Models;

public partial class Crapprover
{
    public int ItcrapproverId { get; set; }

    public int PlantId { get; set; }

    public int SupportId { get; set; }

    public int Crid { get; set; }

    public int? ApproverLevel { get; set; }

    public string? Stage { get; set; }

    public int? ApproverId { get; set; }

    public DateTime ApprovedDt { get; set; }

    public string? Remarks { get; set; }

    public string? Comments { get; set; }

    public string Status { get; set; } = null!;

    public string? Attachment { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
