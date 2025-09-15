namespace IT_Portal.Domain.IT_Models;

public partial class PaygroupMaster
{
    public int Id { get; set; }

    public int? Paygroup { get; set; }

    public string? ShortDesc { get; set; }

    public string? LongDesc { get; set; }

    public string? Plant { get; set; }

    public string? PrintName { get; set; }

    public string? SapDivison { get; set; }

    public string? Glno { get; set; }

    public string? CostCenter { get; set; }

    public string? Email { get; set; }

    public string? EmailHr { get; set; }

    public string? EmailPh { get; set; }

    public string? EmailIt { get; set; }

    public string? Hrid { get; set; }

    public string? PlantHeadId { get; set; }

    public bool? Aoemail { get; set; }

    public bool? Ofemail { get; set; }

    public string? Group { get; set; }

    public string? GroupHead { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<ChecklistConfig> ChecklistConfigs { get; set; } = new List<ChecklistConfig>();

    public virtual ICollection<CompOtRule> CompOtRules { get; set; } = new List<CompOtRule>();

    public virtual ICollection<ContractorMaster> ContractorMasters { get; set; } = new List<ContractorMaster>();

    public virtual ICollection<EmpPaygroupMapping> EmpPaygroupMappings { get; set; } = new List<EmpPaygroupMapping>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<LaRulesM> LaRulesMs { get; set; } = new List<LaRulesM>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    public virtual ICollection<PrintTemplatePpcMapping> PrintTemplatePpcMappings { get; set; } = new List<PrintTemplatePpcMapping>();
}
