namespace IT_Portal.Domain.IT_Models;

public partial class TdTravelBalance
{
    public int AccSubmittedReferenceNoId { get; set; }

    public double TotalAmount { get; set; }

    public double AdvanceAmountPaid { get; set; }

    public double BalanceAmount { get; set; }

    public int? AdvanceChequeNo { get; set; }

    public string? Supportings { get; set; }

    public string? Remarks { get; set; }

    public string? AccSubmittedBy { get; set; }

    public DateTime? AccSubmittedDate { get; set; }
}
