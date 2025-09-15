namespace IT_Portal.Domain.IT_Models;

public partial class ProjectMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? FkParentId { get; set; }

    public int? FkProjectManager { get; set; }

    public int? FkTeamLead { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ApplicableDepartments { get; set; }

    public string? ApplicableUsers { get; set; }

    public string? ApplicablePlants { get; set; }

    public virtual ICollection<ApprovalTemplate> ApprovalTemplates { get; set; } = new List<ApprovalTemplate>();
}
