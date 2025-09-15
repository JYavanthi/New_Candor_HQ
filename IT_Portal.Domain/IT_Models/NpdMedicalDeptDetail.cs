namespace IT_Portal.Domain.IT_Models;

public partial class NpdMedicalDeptDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? DrugRationale { get; set; }

    public string? ProductPatentExpiry { get; set; }

    public string? DcgiApprovalDetails { get; set; }

    public string? DcgiRegulatoryApprovalCost { get; set; }

    public string? DcgiTimelineForApproval { get; set; }

    public string? FinalRecommendation { get; set; }

    public string? Commentsmedical { get; set; }

    public string? Attachments { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? PendingApprover { get; set; }

    public int? ReviewerAssignFlag { get; set; }
}
