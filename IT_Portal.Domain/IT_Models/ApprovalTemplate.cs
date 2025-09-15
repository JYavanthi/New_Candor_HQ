namespace IT_Portal.Domain.IT_Models;

public partial class ApprovalTemplate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ApprovalOrderByHierarchy { get; set; }

    public string? ApprovalOrderByTemplate { get; set; }

    public int? FkProject { get; set; }

    public int? FkSbuId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ProjectMaster? FkProjectNavigation { get; set; }
}
