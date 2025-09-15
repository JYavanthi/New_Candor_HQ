namespace IT_Portal.Domain.IT_Models;

public partial class Asresolution
{
    public int AsresolId { get; set; }

    public int AssetId { get; set; }

    public int ItspareId { get; set; }

    public string? ResolRemarks { get; set; }

    public string? UserRemarks { get; set; }

    public DateTime? ProposedResolDt { get; set; }

    public DateTime? ResolDt { get; set; }

    public string? Description { get; set; }

    public int? OnHoldReason { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
