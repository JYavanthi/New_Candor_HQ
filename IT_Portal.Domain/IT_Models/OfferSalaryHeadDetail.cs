namespace IT_Portal.Domain.IT_Models;

public partial class OfferSalaryHeadDetail
{
    public int OfferSalaryHeadDetailsId { get; set; }

    public int SalaryHeadId { get; set; }

    public decimal Amount { get; set; }

    public decimal AnnualAmount { get; set; }

    public int OfferId { get; set; }

    public virtual OfferDetail Offer { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
