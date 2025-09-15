namespace IT_Portal.Domain.IT_Models;

public partial class NpdIprDeptDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public string? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? PatentStatus { get; set; }

    public string? Attachments { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? PendingApprover { get; set; }

    public string? FinalRecommendation { get; set; }
}
