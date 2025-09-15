namespace IT_Portal.Domain.IT_Models;

public partial class Software
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public string? SoftwareType { get; set; }

    public string? Location { get; set; }

    public int? SrId { get; set; }

    public string? TypeOfDevelopment { get; set; }

    public string? DetailsOfDevelopment { get; set; }

    public string? Department { get; set; }

    public bool? Ifcerequire { get; set; }

    public string? IfcerequireOth { get; set; }

    public string? Ifcewith { get; set; }

    public bool? IsGxpApp { get; set; }

    public bool? NonFunReq { get; set; }

    public string? Brds { get; set; }

    public string? SoftName { get; set; }

    public string? SoftVersionName { get; set; }

    public string? BusJustification { get; set; }

    public string? VendorName { get; set; }

    public string? InstallationType { get; set; }

    public string? LicenceType { get; set; }

    public string? NoOfSusers { get; set; }

    public string? NoOfLisence { get; set; }

    public string? CostPerLisence { get; set; }

    public bool? AmcRequired { get; set; }

    public string? CostForAmc { get; set; }

    public string? ScopeOfAmc { get; set; }

    public bool? IsInstallationRequired { get; set; }

    public int? InstallationCharge { get; set; }

    public string? DetailsOfinstallation { get; set; }

    public DateOnly? DetailsOfinstallationOn { get; set; }

    public string? CurrVersion { get; set; }

    public string? TareVersion { get; set; }

    public string? DetailsOfRequirement { get; set; }

    public string? UsageBy { get; set; }

    public string? WhereHosted { get; set; }

    public string? TypeOfWeb { get; set; }

    public string? UserAccessFrom { get; set; }

    public virtual ICollection<RepositoryDomain> RepositoryDomains { get; set; } = new List<RepositoryDomain>();

    public virtual ICollection<SoftwareModule> SoftwareModules { get; set; } = new List<SoftwareModule>();

    public virtual ICollection<SoftwaresRole> SoftwaresRoles { get; set; } = new List<SoftwaresRole>();

    public virtual ICollection<UserGroupsMaster> UserGroupsMasters { get; set; } = new List<UserGroupsMaster>();

    public virtual ICollection<UserIdEquipmentDetail> UserIdEquipmentDetails { get; set; } = new List<UserIdEquipmentDetail>();

    public virtual ICollection<UserIdMasterDetail> UserIdMasterDetails { get; set; } = new List<UserIdMasterDetail>();

    public virtual ICollection<UserIdRequestOld> UserIdRequestOlds { get; set; } = new List<UserIdRequestOld>();

    public virtual ICollection<UserSubgroupsMaster> UserSubgroupsMasters { get; set; } = new List<UserSubgroupsMaster>();
}
