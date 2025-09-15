namespace IT_Portal.Domain.IT_Models;

public partial class PlantMaster
{
    public int Id { get; set; }

    public int? Locid { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? ToMail { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? OutwardMail { get; set; }

    public string? VisitorMail { get; set; }

    public bool? IsActive { get; set; }

    public int? PlantType { get; set; }

    public string? PrintName { get; set; }

    public string? LocHead { get; set; }

    public string? LocGroup { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<ChecklistConfig> ChecklistConfigs { get; set; } = new List<ChecklistConfig>();

    public virtual ICollection<CompOtRule> CompOtRules { get; set; } = new List<CompOtRule>();

    public virtual ICollection<ContractorMaster> ContractorMasters { get; set; } = new List<ContractorMaster>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<GuestHouseMaster> GuestHouseMasters { get; set; } = new List<GuestHouseMaster>();

    public virtual ICollection<LaRulesM> LaRulesMs { get; set; } = new List<LaRulesM>();

    public virtual ICollection<LocationGateMaster> LocationGateMasters { get; set; } = new List<LocationGateMaster>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    public virtual ICollection<PlantsAssignedForUserId> PlantsAssignedForUserIds { get; set; } = new List<PlantsAssignedForUserId>();

    public virtual ICollection<PrintTemplatePpcMapping> PrintTemplatePpcMappings { get; set; } = new List<PrintTemplatePpcMapping>();

    public virtual ICollection<RoomMaster> RoomMasters { get; set; } = new List<RoomMaster>();

    public virtual ICollection<Sla> Slas { get; set; } = new List<Sla>();

    public virtual ICollection<UserIdRequestOld> UserIdRequestOlds { get; set; } = new List<UserIdRequestOld>();

    public virtual ICollection<UserPlantMaintenance> UserPlantMaintenances { get; set; } = new List<UserPlantMaintenance>();
}
