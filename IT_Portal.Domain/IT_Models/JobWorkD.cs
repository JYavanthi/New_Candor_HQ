namespace IT_Portal.Domain.IT_Models;

public partial class JobWorkD
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public int? FkJobWorkM { get; set; }

    public string? ChallenNo { get; set; }

    public string? ItemCode { get; set; }

    public string? ItemDesc { get; set; }

    public string? HsnCode { get; set; }

    public string? Uom { get; set; }

    public string? BatchNo { get; set; }

    public decimal? Qty { get; set; }

    public string? PackingDetails { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Amount { get; set; }

    public string? TotalDcValue { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
