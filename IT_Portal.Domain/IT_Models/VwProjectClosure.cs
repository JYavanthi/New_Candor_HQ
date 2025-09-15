namespace IT_Portal.Domain.IT_Models;

public partial class VwProjectClosure
{
    public int ClosureId { get; set; }

    public int? ProjectId { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

    public string? Attachment { get; set; }

    public string? LessonsLearnt { get; set; }

    public string? Task { get; set; }

    public string? Category { get; set; }

    public string? ProblemsStatement { get; set; }

    public string? Impact { get; set; }

    public string? Recommendation { get; set; }

    public string? Feedback { get; set; }

    public bool? IsSponsor { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
