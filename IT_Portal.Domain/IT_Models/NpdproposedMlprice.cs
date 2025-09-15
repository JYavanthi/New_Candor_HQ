namespace IT_Portal.Domain.IT_Models;

public partial class NpdproposedMlprice
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Sku { get; set; }

    public string? PackSize { get; set; }

    public string? MrpperUnit { get; set; }

    public string? GovernmentPricing { get; set; }
}
