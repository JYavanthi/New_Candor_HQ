namespace IT_Portal.Domain.IT_Models;

public partial class CommonUserIdmaster
{
    public int Id { get; set; }

    public int Sid { get; set; }

    public int LocationId { get; set; }

    public int DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    public string? RequestNumber { get; set; }

    public string? UserId { get; set; }

    public string? SoftwareRole { get; set; }

    public string? SoftwareType { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Category { get; set; }

    public string? TrainingRecord { get; set; }

    public string? DateOfTraining { get; set; }

    public string? JobDescription { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public string? PlantsAssigned { get; set; }

    public string? UserGroups { get; set; }

    public string? UserSubgroups { get; set; }

    public string? OtherSubgroups { get; set; }

    public string? MasterAssignment { get; set; }

    public string? RequiredModuleAccess { get; set; }

    public string? RepositoryDomains { get; set; }

    public string? Status { get; set; }

    public string? EquipmentName { get; set; }

    public string? EquipmentId { get; set; }

    public string? AreaOrLocation { get; set; }
}
