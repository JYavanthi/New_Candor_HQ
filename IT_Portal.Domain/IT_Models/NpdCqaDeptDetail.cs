namespace IT_Portal.Domain.IT_Models;

public partial class NpdCqaDeptDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? CeilingPrice { get; set; }

    public string? WhetherNewDrugRequiringDcgPermission { get; set; }

    public string? WhetherCoveredUnderBannedDrugDcg { get; set; }

    public string? LocalFdaLicense { get; set; }

    public string? Timeline { get; set; }

    public string? Remarks { get; set; }

    public string? NpdReferenceNo { get; set; }

    public string? TradePsArtworkPrintApproval { get; set; }

    public string? ActualSampleTradePsCarton { get; set; }

    public string? ReferenceNoGivenBy { get; set; }

    public string? ReferenceDate { get; set; }

    public string? Attachments { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? PendingApprover { get; set; }

    public string? FinalRecommendation { get; set; }

    public int? Cqacost { get; set; }
}
