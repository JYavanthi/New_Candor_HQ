namespace IT_Portal.Domain.IT_Models;

public partial class ProdUserIdMasterDetail
{
    public int Id { get; set; }

    public int? Sid { get; set; }

    public int? LocationId { get; set; }

    public string? EmployeeId { get; set; }

    public string? UserId { get; set; }

    public string? SoftwareRole { get; set; }

    public string? AssignedPlants { get; set; }

    public string? UserGroups { get; set; }

    public string? UserSubGroups { get; set; }

    public string? RepositoryDomains { get; set; }

    public string? MasterAssignment { get; set; }

    public string? Salutation { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Category { get; set; }

    public string? EquipmentName { get; set; }

    public string? SoftwareType { get; set; }

    public string? Status { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? EquipmentId { get; set; }

    public string? AreaorLocation { get; set; }
}
