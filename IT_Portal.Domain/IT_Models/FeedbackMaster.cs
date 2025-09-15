namespace IT_Portal.Domain.IT_Models;

public partial class FeedbackMaster
{
    public int Id { get; set; }

    public int? FkEmpId { get; set; }

    public string? Description { get; set; }

    public string? Resolution { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ResolveBy { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public bool IsActive { get; set; }
}
