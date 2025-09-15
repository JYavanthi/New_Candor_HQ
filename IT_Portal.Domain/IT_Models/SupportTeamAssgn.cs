namespace IT_Portal.Domain.IT_Models;

public partial class SupportTeamAssgn
{
    public int SupportTeamAssgnId { get; set; }

    public int SupportTeamId { get; set; }

    public int SupportId { get; set; }

    public int? CategoryId { get; set; }

    public int? ClassificationId { get; set; }

    public int? CategoryTypId { get; set; }

    public int? PlantId { get; set; }

    public bool? IsApprover { get; set; }

    public bool? IsChangeAnalyst { get; set; }

    public bool? IsSupportEngineer { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsSuperAdmin { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
