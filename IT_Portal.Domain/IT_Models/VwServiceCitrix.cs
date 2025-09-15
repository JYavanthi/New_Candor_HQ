namespace IT_Portal.Domain.IT_Models;

public partial class VwServiceCitrix
{
    public int ServiceCitrixId { get; set; }

    public string? ServiceCode { get; set; }

    public int RaisedBy { get; set; }

    public DateTime Srdate { get; set; }

    public string ShotDesc { get; set; } = null!;

    public string Srdesc { get; set; } = null!;

    public int? SrraiseForid { get; set; }

    public string? SrraiseFor { get; set; }
}
