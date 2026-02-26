using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Category
{
    public int ItcategoryId { get; set; }

    public int? SupportId { get; set; }

    public string? CategoryName { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual ICollection<ChangeRequest> ChangeRequests { get; set; } = new List<ChangeRequest>();

    public virtual ICollection<RiskPlan> RiskPlans { get; set; } = new List<RiskPlan>();

    public virtual ICollection<Sla> Slas { get; set; } = new List<Sla>();

    public virtual ICollection<SysLandscape> SysLandscapes { get; set; } = new List<SysLandscape>();
}
