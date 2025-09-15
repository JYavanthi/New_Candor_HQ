namespace IT_Portal.Domain.IT_Models;

public partial class NpdmarketInformation
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? Country { get; set; }

    public string? MarketSize { get; set; }

    public string? MarketGrowthPercentage { get; set; }

    public string? ExpectedMlmarketShareYear1 { get; set; }

    public string? ExpectedMlmarketShareYear2 { get; set; }

    public string? ExpectedMlmarketShareYear3 { get; set; }
}
