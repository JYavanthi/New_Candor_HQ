namespace IT_Portal.Domain.IT_Models;

public partial class ProjectDeliverable
{
    public int DeliverablesId { get; set; }

    public int ProjectId { get; set; }

    public string? DeliverablesText { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
