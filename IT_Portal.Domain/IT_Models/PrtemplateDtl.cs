namespace IT_Portal.Domain.IT_Models;

public partial class PrtemplateDtl
{
    public int PrtemplateDtlsId { get; set; }

    public string? Task { get; set; }

    public string? Category { get; set; }

    public string? LessonType { get; set; }

    public string? Description { get; set; }

    public string? Impact { get; set; }

    public string? Recommendation { get; set; }

    public int? PrtemplateId { get; set; }

    public int? TaskId { get; set; }

    public int? MilestoneId { get; set; }

    public string? Question { get; set; }

    public string? Type { get; set; }

    public string? Value { get; set; }

    public bool? Mandatory { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
