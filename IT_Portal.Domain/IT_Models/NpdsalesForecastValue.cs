namespace IT_Portal.Domain.IT_Models;

public partial class NpdsalesForecastValue
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Sku { get; set; }

    public decimal? Year1 { get; set; }

    public string? Year1Units { get; set; }

    public decimal? Year2 { get; set; }

    public string? Year2Units { get; set; }

    public decimal? Year3 { get; set; }

    public string? Year3Units { get; set; }
}
