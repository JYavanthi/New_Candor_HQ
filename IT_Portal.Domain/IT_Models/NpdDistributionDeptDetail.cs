namespace IT_Portal.Domain.IT_Models;

public partial class NpdDistributionDeptDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? RemarksDistribution { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? ReviewDistribution { get; set; }

    public string? FinalRecommendation { get; set; }
}
