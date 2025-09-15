namespace IT_Portal.Domain.IT_Models;

public partial class NpdsalesForecastUnit
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Sku { get; set; }

    public int? PackSize { get; set; }

    public int? Month1 { get; set; }

    public int? Month2 { get; set; }

    public int? Month3 { get; set; }

    public int? Month4 { get; set; }

    public int? Month5 { get; set; }

    public int? Month6 { get; set; }

    public int? Month7 { get; set; }

    public int? Month8 { get; set; }

    public int? Month9 { get; set; }

    public int? Month10 { get; set; }

    public int? Month11 { get; set; }

    public int? Month12 { get; set; }

    public int? Year1 { get; set; }

    public int? Year2 { get; set; }

    public int? Year3 { get; set; }
}
