namespace IT_Portal.Domain.IT_Models;

public partial class PayslipRequest
{
    public int ReqId { get; set; }

    public string? ReqType { get; set; }

    public string? ReqBy { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public DateTime? ReqDate { get; set; }

    public string? Status { get; set; }

    public string? SapStatus { get; set; }

    public DateTime? SapApprovedDate { get; set; }

    public string? SapMessage { get; set; }

    public bool? SapSentFlag { get; set; }
}
