namespace IT_Portal.Domain.IT_Models;

public partial class NpdSupplychainDeptDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? ManufacturingLocationInhouse { get; set; }

    public string? RecommendedOutsourcedThirdPartyLocation { get; set; }

    public string? DcgiApprovalStatus { get; set; }

    public string? LocalStateDrugLicense { get; set; }

    public string? TimelineDevelopmentCommercialisation { get; set; }

    public string? PreNegotiatedTransferPrice { get; set; }

    public string? SupplyChainRemarks { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? PendingApprover { get; set; }

    public string? ForFirstCommercialLaunch { get; set; }

    public string? ForAnnual { get; set; }

    public string? FinalRecommendation { get; set; }
}
