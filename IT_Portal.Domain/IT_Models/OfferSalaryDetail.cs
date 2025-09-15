namespace IT_Portal.Domain.IT_Models;

public partial class OfferSalaryDetail
{
    public int OfferSalaryDetailsId { get; set; }

    public decimal OfferedSalary { get; set; }

    public string? SalaryType { get; set; }

    public string? PackageType { get; set; }

    public int OfferId { get; set; }

    public virtual OfferDetail Offer { get; set; } = null!;
}
