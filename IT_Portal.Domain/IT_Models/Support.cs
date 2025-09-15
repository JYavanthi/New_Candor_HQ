namespace IT_Portal.Domain.IT_Models;

public partial class Support
{
    public int SupportId { get; set; }

    public string SupportName { get; set; } = null!;

    public int? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsRpmreq { get; set; }

    public bool? IsHodreq { get; set; }

    public string? Image { get; set; }

    public string? Url { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Approver> Approvers { get; set; } = new List<Approver>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Checklist> Checklists { get; set; } = new List<Checklist>();

    public virtual ICollection<RiskPlan> RiskPlans { get; set; } = new List<RiskPlan>();

    public virtual ICollection<ServiceMaster1> ServiceMaster1s { get; set; } = new List<ServiceMaster1>();

    public virtual ICollection<Sla> Slas { get; set; } = new List<Sla>();

    public virtual ICollection<SysLandscape> SysLandscapes { get; set; } = new List<SysLandscape>();
}
