namespace IT_Portal.Domain.IT_Models;

public partial class EmpCategoryMaster
{
    public int Id { get; set; }

    public int Staffcat { get; set; }

    public string? Catstxt { get; set; }

    public string? Catltxt { get; set; }

    public string? Glno { get; set; }

    public string? CostCenter { get; set; }

    public string? Bemnth { get; set; }

    public int? Prcday { get; set; }

    public string? Aoemail { get; set; }

    public string? Ofemail { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<ChecklistConfig> ChecklistConfigs { get; set; } = new List<ChecklistConfig>();

    public virtual ICollection<CompOtRule> CompOtRules { get; set; } = new List<CompOtRule>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<LaRulesM> LaRulesMs { get; set; } = new List<LaRulesM>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    public virtual ICollection<PrintTemplatePpcMapping> PrintTemplatePpcMappings { get; set; } = new List<PrintTemplatePpcMapping>();
}
