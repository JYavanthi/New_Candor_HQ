namespace IT_Portal.Domain.IT_Models;

public partial class NpdcompetitorBrand1
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ProductName { get; set; }

    public string? Sales { get; set; }

    public string? ExistingMarketShare { get; set; }

    public string? MrpperUnit { get; set; }

    public string? CompanyName { get; set; }

    public string? DosageStrength { get; set; }

    public string? DosageForm { get; set; }

    public string? Packaging { get; set; }

    public string? GrowthPercentage { get; set; }

    public string? PackSize { get; set; }
}
