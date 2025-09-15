namespace IT_Portal.Domain.IT_Models;

public partial class EssRestrictionRule
{
    public int? Pernr { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? DeleteFlag { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Prefix { get; set; }
}
