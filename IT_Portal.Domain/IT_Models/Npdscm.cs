namespace IT_Portal.Domain.IT_Models;

public partial class Npdscm
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public string ResponsibleEmployeeId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ManufacturingLocationIfInHouse { get; set; }

    public string? FinalRecommendation { get; set; }

    public string? P2pvendorName { get; set; }

    public string? P2plocation { get; set; }

    public string? Coaattachments { get; set; }

    public decimal? Scmcost { get; set; }

    public string? DcgiapprovalStatus { get; set; }

    public string? LocalFdalicense { get; set; }

    public int? Timeline { get; set; }

    public string? TimelineUnit { get; set; }

    public decimal? TentativeRawMaterialCost { get; set; }

    public string? TentativeRawMaterialCostUnit { get; set; }

    public decimal? TentativeManufacturingCost { get; set; }

    public string? TentativeManufacturingCostUnit { get; set; }

    public decimal? AnyOtherCost { get; set; }

    public string? AnyOtherCostUnit { get; set; }

    public string? ScmcostUnit { get; set; }
}
