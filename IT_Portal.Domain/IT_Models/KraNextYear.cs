namespace IT_Portal.Domain.IT_Models;

public partial class KraNextYear
{
    public int Id { get; set; }

    public int? FkAssesmentId { get; set; }

    public string? KraName { get; set; }

    public string? Task { get; set; }

    public double? Weightage { get; set; }

    public DateOnly? TargetDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual AssesmentMaster? FkAssesment { get; set; }
}
