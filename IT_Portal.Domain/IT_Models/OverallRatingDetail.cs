namespace IT_Portal.Domain.IT_Models;

public partial class OverallRatingDetail
{
    public int Id { get; set; }

    public int? FkAssesmentId { get; set; }

    public string? Rating { get; set; }

    public string? RatingEmp { get; set; }

    public string? FeedbackComments { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual AssesmentMaster? FkAssesment { get; set; }
}
