namespace IT_Portal.Domain.IT_Models;

public partial class TrainingDetail
{
    public int Id { get; set; }

    public int? FkAssesmentId { get; set; }

    public string? AttendedCurrentYear { get; set; }

    public string? AttendedNextYear { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual AssesmentMaster? FkAssesment { get; set; }
}
